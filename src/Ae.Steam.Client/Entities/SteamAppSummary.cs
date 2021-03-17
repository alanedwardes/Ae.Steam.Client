using System;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamAppSummary
    {
        [JsonPropertyName("appid")]
        public uint AppId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public Uri StorePage => new Uri($"https://store.steampowered.com/app/{AppId}");

        public override string ToString() => $"{Name} ({AppId})";
    }
}
