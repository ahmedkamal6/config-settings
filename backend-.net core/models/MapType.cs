using System.Text.Json.Serialization;

namespace config_server.models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum MapType
    {
        Features = 1, 
        BaseMap = 2
    }
}