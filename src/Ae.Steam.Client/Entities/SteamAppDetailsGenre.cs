using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsGenre
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override string ToString() => Description;
    }
}
