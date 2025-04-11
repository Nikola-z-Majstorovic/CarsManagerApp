using System.Text.Json.Serialization;

namespace MyBackend.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FuelTypes
    {
        DIESEL,
        SUPER
    }
}
