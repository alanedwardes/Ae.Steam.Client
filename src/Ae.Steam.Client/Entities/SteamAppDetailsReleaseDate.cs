using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsReleaseDate
    {
        [JsonPropertyName("coming_soon")]
        public bool ComingSoon { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }

        public override string ToString() => Date;
    }
}
