using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using WebApiNetCore5.Dtos;
using WebApiNetCore5.Models;

namespace WebApiNetCore5.Servicio
{
    public class ServicioEncriptacion
    {
        private readonly IDataProtectionProvider _protector;

        public ServicioEncriptacion(IDataProtectionProvider protectorProvider)
        {
            _protector = protectorProvider;
        }

        public UserEncriptadoTest MapToWraperEntities(UserPruebaDto profileDto)
        {
            return new UserEncriptadoTest
            {
                Name = profileDto.Name,
                //Email = _protector.Protect(profileDto.Email),
                Age = profileDto.Age
            };
        }
    }
}
