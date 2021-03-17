using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsCategory
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override string ToString() => Description;
    }
}
