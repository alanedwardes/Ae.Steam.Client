using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsSupportInfo
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

        public override string? ToString() => Url?.ToString();
    }
}
