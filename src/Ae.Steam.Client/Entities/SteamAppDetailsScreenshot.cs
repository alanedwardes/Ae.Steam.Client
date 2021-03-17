using System;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsScreenshot
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }
        [JsonPropertyName("path_thumbnail")]
        public Uri Thumbnail { get; set; }
        [JsonPropertyName("path_full")]
        public Uri Full { get; set; }

        public override string? ToString() => Full?.ToString();
    }
}
