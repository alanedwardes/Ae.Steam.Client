using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamReviewSummary
    {
        [JsonPropertyName("num_reviews")]
        public uint NumReviews { get; set; }
        [JsonPropertyName("review_score")]
        public uint ReviewScore { get; set; }
        [JsonPropertyName("review_score_desc")]
        public string ReviewScoreDescription { get; set; }
        [JsonPropertyName("total_positive")]
        public uint TotalPositive { get; set; }
        [JsonPropertyName("total_negative")]
        public uint TotalNegative { get; set; }
        [JsonPropertyName("total_reviews")]
        public uint TotalReviews { get; set; }
    }
}
