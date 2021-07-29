using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiNetCore5.Dtos;
using WebApiNetCore5.Models;

namespace WebApiNetCore5.Servicio
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserPruebaDto, UserEncriptadoTest>().AfterMap<SetTraceIdentifierAction>();
            CreateMap<UserEncriptadoTest,UserPruebaDto>().AfterMap<SetReturn>();
        }
    }
}
