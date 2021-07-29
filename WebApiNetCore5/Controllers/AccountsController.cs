using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApiNetCore5.Contexts;
using WebApiNetCore5.Models;

namespace WebApiNetCore5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        [HttpPost("Crear")]
        public async Task<ActionResult> CreateUser([FromBody] UserInfo model) {
            var user = new ApplicationUser { 
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> LoginUser([FromBody] UserInfo model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false,true);
            if (result.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                if (result.IsNotAllowed)
                {
                    var yaTiene = await _appDbContext.UserCodeTokens.AnyAsync(x => x.UserId == model.Email && x.ExpirationDate > DateTime.Now);
                    if (!yaTiene)
                    {

                        var tolo = await _userManager.FindByEmailAsync(model.Email);


                        var tender = await _userManager.GenerateEmailConfirmationTokenAsync(tolo);

                        var cidigo = Guid.NewGuid();
                        _appDbContext.UserCodeTokens.Add(new UserCodeToken
                        {
                            Code = cidigo.ToString().Substring(0, 8).Replace("-", String.Empty),
                            Token = tender,
                            UserId = model.Email,
                            ExpirationDate = DateTime.Now.AddDays(1)
                        });

                        await _appDbContext.SaveChangesAsync();
                    }
                    //aqui deberia enviar el token o generar el codigo
                }

                return Unauthorized(result);
            }

        }

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgetPassword([FromBody] UserInfo model)
        {
            await generarCodigo(model);
            return Ok();
        }

        private async Task generarCodigo(UserInfo model)
        {
            var yaTiene = await _appDbContext.UserCodeTokens.AnyAsync(x => x.UserId == model.Email && x.ExpirationDate > DateTime.Now);
            if (!yaTiene)
            {

                var tolo = await _userManager.FindByEmailAsync(model.Email);


                var tender = await _userManager.GenerateEmailConfirmationTokenAsync(tolo);

                var cidigo = Guid.NewGuid();
                _appDbContext.UserCodeTokens.Add(new UserCodeToken
                {
                    Code = cidigo.ToString().Substring(0, 8).Replace("-", String.Empty),
                    Token = tender,
                    UserId = model.Email,
                    ExpirationDate = DateTime.Now.AddDays(1)
                });

                await _appDbContext.SaveChangesAsync();
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangeInfoUser model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.ChangePasswordAsync(user,model.Password,model.NewPass);
            if (result.Succeeded)
            {
                return Ok("The password is changed correctly.");
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }

        [HttpPost("RestorePassword")]
        public async Task<ActionResult> RestaurarPass([FromBody] UserInfo model, [FromHeader] string code)
        {
            var existe = await _appDbContext.UserCodeTokens.AnyAsync(x => x.UserId == model.Email && x.Code == code && x.IsUsed == false);
            if (existe) 
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                var tolo = await _userManager.RemovePasswordAsync(user);

                var tender = await _userManager.AddPasswordAsync(user, model.Password);

                if (tender.Succeeded)
                {
                    var token = await _appDbContext.UserCodeTokens.SingleOrDefaultAsync(x => x.UserId == model.Email && x.Code == code);
                    token.IsUsed = true;
                    return Ok();
                }
                else
                {
                    return BadRequest(tender.Errors);
                }
            }

            return BadRequest();

        }

        [HttpPost("ValidarCodigo")]
        public async Task<ActionResult> ValidarCodigo([FromBody] RestoreCode model)
        {
            var existe = await _appDbContext.UserCodeTokens.AnyAsync(x => x.UserId == model.Email && x.ExpirationDate > DateTime.Now && x.Code == model.Code);
            if (existe)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                var token = await _appDbContext.UserCodeTokens.SingleOrDefaultAsync(x => x.UserId == model.Email && x.Code == model.Code);

                if (!token.IsUsed)
                {
                    var tender = await _userManager.ConfirmEmailAsync(user, token.Token);
                    if (tender.Succeeded)
                    {
                        return Ok();
                    }

                    return BadRequest(tender.Errors);
                }

                return BadRequest("Toekn is used.");

            }

            return BadRequest("Token not exist");

        }

        private UserToken BuildToken(UserInfo u) {
            var claims = new[] { 
                new Claim(JwtRegisteredClaimNames.UniqueName, u.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(5);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return new UserToken { 
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
