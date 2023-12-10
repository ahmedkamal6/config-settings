using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using config_server.Models;
using config_server.Services;
using config_server.models;
using config_server.Dtos;
namespace config_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {   
            _configService = configService;
        }

        [HttpGet("getConfig")]
        public async Task<ActionResult<ServiceResponse<GetConfigDto>>> GetConfig(int id){
            var response = await _configService.GetConfig(id);
            return Ok(response);
        }
        [HttpPost("addConfig")]
        public async Task<ActionResult<ServiceResponse<GetConfigDto>>> AddConfig(AddConfigDto config){
            return Ok(await _configService.AddConfig(config));
        }
        [HttpPut("updateConfig")]
        public async Task<ActionResult<ServiceResponse<UpdateConfigDto>>> updateConfig(UpdateConfigDto config){
            var response = await _configService.UpdateConfig(config);
            if(response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("deleteConfig")]
        public async Task<ActionResult<ServiceResponse<bool>>> deleteConfig(int id){
            var response = await _configService.DeleteConfig(id);
            if(response.Data)
                return Ok(response);
            return NotFound(response);
        }
    }
}