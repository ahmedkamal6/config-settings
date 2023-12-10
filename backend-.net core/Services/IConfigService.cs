using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using config_server.Dtos;
using config_server.models;
using config_server.Models;

namespace config_server.Services
{
    public interface IConfigService
    {
        Task<ServiceResponse<GetConfigDto>> GetConfig(int id);
        Task<ServiceResponse<GetConfigDto>> AddConfig(AddConfigDto config);
        Task<ServiceResponse<GetConfigDto>> UpdateConfig(UpdateConfigDto config);
        Task<ServiceResponse<bool>> DeleteConfig(int id);
    }
}