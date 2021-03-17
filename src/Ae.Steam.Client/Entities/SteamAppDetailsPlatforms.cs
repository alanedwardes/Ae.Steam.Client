using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsPlatforms
    {
        [JsonPropertyName("windows")]
        public bool Windows { get; set; }
        [JsonPropertyName("mac")]
        public bool Mac { get; set; }
        [JsonPropertyName("linux")]
        public bool Linux { get; set; }
    }
}
