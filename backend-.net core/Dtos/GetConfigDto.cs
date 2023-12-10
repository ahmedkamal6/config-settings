using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using config_server.models;

namespace config_server.Dtos
{
    public class GetConfigDto
    {
        
        public int Id { get; set; }
        public float ClusterRadius { get; set; }
        public bool GeoFencing { get; set; }
        public float TimeBuffer { get; set; }
        public float LocationBuffer{ get; set; }
        public int Duration { get; set; }
        public MapType MapType { get; set; }
        public MapSubType MapSubType { get; set; }
    }
}