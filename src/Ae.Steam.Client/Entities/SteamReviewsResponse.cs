using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamReviewsResponse
    {
        [JsonPropertyName("query_summary")]
        public SteamReviewSummary Summary { get; set; }
        [JsonPropertyName("reviews")]
        public IReadOnlyList<SteamReview> Reviews { get; set; } = new SteamReview[0];
    }
}
