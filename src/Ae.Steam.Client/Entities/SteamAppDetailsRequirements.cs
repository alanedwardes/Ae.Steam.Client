using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsRequirements
    {
        [JsonPropertyName("minimum")]
        public string? Minimum { get; set; }
        [JsonPropertyName("recommended")]
        public string? Recommended { get; set; }

        public override string? ToString() => Recommended ?? Minimum;
    }
}
