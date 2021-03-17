using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public sealed class SteamAppDetailsPriceOverview
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("initial")]
        public int Initial { get; set; }
        [JsonPropertyName("final")]
        public int Final { get; set; }
        [JsonPropertyName("discount_percent")]
        public int DiscountPercent { get; set; }
        [JsonPropertyName("initial_formatted")]
        public string InitialFormatted { get; set; }
        [JsonPropertyName("final_formatted")]
        public string FinalFormatted { get; set; }

        public override string ToString() => FinalFormatted;
    }
}
