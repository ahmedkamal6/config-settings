using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using config_server.Data;
using config_server.Dtos;
using config_server.models;
using config_server.Models;
using Microsoft.EntityFrameworkCore;

namespace config_server.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ConfigService(IMapper mapper,DataContext context){
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetConfigDto>> AddConfig(AddConfigDto config)
        {
            try
            {
            var configResponse = new ServiceResponse<GetConfigDto>{message="config Added successfully"}; 
            var newConfig = _mapper.Map<Config>(config);
            _context.Config.Add(newConfig);
            await _context.SaveChangesAsync();
            configResponse.Data = _mapper.Map<GetConfigDto>(newConfig);
            configResponse.Success = true;
            Console.WriteLine("added");
            return configResponse;
            }
            catch (Exception)
            {
                throw new Exception("error");
            }
            
        }

        public async Task<ServiceResponse<bool>> DeleteConfig(int id)
        {
            var configResponse = new ServiceResponse<bool>();
            var DBconfig = await _context.Config.ToListAsync();
            foreach(var conf in DBconfig){
                if(conf.Id == id)
                {
                    _context.Remove(conf);
                    await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Config;");
                    configResponse.Data = true;
                    configResponse.Success = true;
                    configResponse.message = "config deleted successfully";
                    return configResponse;
                }
            }
            configResponse.message = "config not found";
            return configResponse;
        }

        public async Task<ServiceResponse<GetConfigDto>> GetConfig(int id)
        {
            var configResponse = new ServiceResponse<GetConfigDto>(); 
            var DBconfig = await _context.Config.ToListAsync();
            foreach(var conf in DBconfig){
                if(conf.Id == id)
                {       
                    configResponse.Data = _mapper.Map<GetConfigDto>(conf);
                    configResponse.Success = true;
                    configResponse.message = "config found";
                    return configResponse; 
                }   
            } 
            configResponse.Success = false;
            configResponse.message = "config not found";
            return configResponse;
        }
        public async Task<ServiceResponse<GetConfigDto>> UpdateConfig(UpdateConfigDto config)
        {
            var configResponse = new ServiceResponse<GetConfigDto>(); 
            var DBconfig = await _context.Config.ToListAsync();
            foreach(var conf in DBconfig){
                if(conf.Id == config.Id)
                {
                    conf.ClusterRadius = config.ClusterRadius;
                    conf.GeoFencing = config.GeoFencing;
                    conf.TimeBuffer = config.TimeBuffer;
                    conf.LocationBuffer = config.LocationBuffer;
                    conf.Duration = config.Duration;
                    conf.MapType = config.MapType;
                    conf.MapSubType = config.MapSubType;
                    _context.Update(conf);   
                    await _context.SaveChangesAsync();    
                    configResponse.Data = _mapper.Map<GetConfigDto>(conf);
                    configResponse.Success = true;
                    configResponse.message = "config found";
                    return configResponse; 
                }   
            } 
            configResponse.message = "config not found";
            return configResponse;

        }
    }
}