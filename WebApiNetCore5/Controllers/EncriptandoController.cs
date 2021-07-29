using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNetCore5.Contexts;
using WebApiNetCore5.Dtos;
using WebApiNetCore5.Models;
using WebApiNetCore5.Servicio;

namespace WebApiNetCore5.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EncriptandoController : ControllerBase
    {
        //private readonly IPutPersonalProfileDependencies _dependencies;
        //private readonly IDataProtectionProvider _protector;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public EncriptandoController( AppDbContext appDbContext, IMapper mapper)
        {
            //_protector = protector;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<UserEncriptadoTest> Get() 
        {
            var key = Guid.NewGuid().ToString();
            var usDto = new UserPruebaDto { 
                Name = "pipo",
                Email = "monacho",
                Age = 2,
                Key = key
            };

            var usN = _mapper.Map<UserPruebaDto,UserEncriptadoTest> (usDto);

            var regreso = _mapper.Map<UserEncriptadoTest, UserPruebaDto>(usN);

            return Ok();
        }

        [HttpPost("CrearPrueba")]
        public async Task<ActionResult> CreateUser([FromBody] UserPruebaDto model)
        {
            var key = Guid.NewGuid().ToString();
            //var protector = _protector.CreateProtector(key);
            model.Key = key;

            var nUser = _mapper.Map<UserPruebaDto, UserEncriptadoTest>(model);
            //var nUser = new UserEncriptadoTest { 
            //    Name = model.Name,
            //    Email = protector.Protect(model.Email),
            //    Age = model.Age
            //};

            _appDbContext.UserEncriptadoTests.Add(nUser);
            await _appDbContext.SaveChangesAsync();

            return Ok(key);
        }

        [HttpPost("Consultar")]
        public async Task<ActionResult<UserPruebaDto>> GetUser([FromBody] FindUserDto find)
        {
            //var key = Guid.NewGuid().ToString();
            //var protector = _protector.CreateProtector(find.Key);

            var existe = await _appDbContext.UserEncriptadoTests.AnyAsync(x => x.Name.ToUpper() == find.Name.ToUpper());
            if (existe)
            {
                var usuario = await _appDbContext.UserEncriptadoTests.SingleOrDefaultAsync(x => x.Name.ToUpper() == find.Name.ToUpper());
                usuario.Key = find.Key;
                var regreso = _mapper.Map<UserEncriptadoTest, UserPruebaDto>(usuario);

                //return new UserPruebaDto {
                //    Name = usuario.Name,
                //    Email = protector.Unprotect(usuario.Email),
                //    Age = usuario.Age
                //};
                return regreso;
            }

            return BadRequest();
        }
    }
}
