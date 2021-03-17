using System;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsMoviePaths
    {
        [JsonPropertyName("480")]
        public Uri Size480 { get; set; }
        [JsonPropertyName("max")]
        public Uri Max { get; set; }

        public override string? ToString() => Max?.ToString();
    }
}
