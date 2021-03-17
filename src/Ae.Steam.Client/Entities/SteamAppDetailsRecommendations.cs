using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsRecommendations
    {
        [JsonPropertyName("total")]
        public uint Total { get; set; }

        public override string ToString() => Total.ToString();
    }
}
