using System;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsMovie
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("thumbnail")]
        public Uri Thumbnail { get; set; }
        [JsonPropertyName("webm")]
        public SteamAppDetailsMoviePaths WebmFormat { get; set; }
        [JsonPropertyName("mp4")]
        public SteamAppDetailsMoviePaths Mp4Format { get; set; }
        [JsonPropertyName("highlight")]
        public bool Highlight { get; set; }

        public override string ToString() => Name;
    }
}
