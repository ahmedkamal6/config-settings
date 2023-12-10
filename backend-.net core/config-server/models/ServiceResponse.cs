using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace config_server.models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success {get; set;}
        public string message {get;set;} = string.Empty;
    }
}