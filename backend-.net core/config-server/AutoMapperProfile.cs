using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using config_server.Dtos;
using config_server.Models;

namespace config_server
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Config,GetConfigDto>();
            CreateMap<AddConfigDto,Config>();
            CreateMap<UpdateConfigDto,Config>();
        }
    }
}