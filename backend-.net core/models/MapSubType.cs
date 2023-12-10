using System.Text.Json.Serialization;

namespace config_server.models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MapSubType
    {
        Dynamic = 1,
        Cached = 2,
        Imagery = 3,
        Topographic = 4
    }
}