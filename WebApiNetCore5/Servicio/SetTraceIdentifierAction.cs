using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApiNetCore5.Dtos;
using WebApiNetCore5.Models;

namespace WebApiNetCore5.Servicio
{
    public class SetTraceIdentifierAction : IMappingAction<UserPruebaDto, UserEncriptadoTest>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataProtectionProvider _protector;
        public SetTraceIdentifierAction(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider protector)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _protector = protector;
        }

        public void Process(UserPruebaDto source, UserEncriptadoTest destination, ResolutionContext context)
        {
            var protector = _protector.CreateProtector(source.Key);
            destination.Email = protector.Protect(source.Email);
            //destination.TraceIdentifier = _httpContextAccessor.HttpContext.TraceIdentifier;
        }
    }

    public class SetReturn : IMappingAction<UserEncriptadoTest, UserPruebaDto>
    {
        private readonly IDataProtectionProvider _protector;

        public SetReturn(IDataProtectionProvider protector)
        {
            _protector = protector;
        }

        public void Process(UserEncriptadoTest source, UserPruebaDto destination, ResolutionContext context)
        {
            var protector = _protector.CreateProtector(source.Key);
            destination.Email = protector.Unprotect(source.Email);
        }
    }
}
