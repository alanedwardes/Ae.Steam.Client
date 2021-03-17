using System;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamReview
    {
        [JsonPropertyName("recommendationid")]
        public string RecommendationId { get; set; }
        [JsonPropertyName("author")]
        public SteamReviewAuthor Author { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("review")]
        public string Comment { get; set; }
        [JsonPropertyName("timestamp_created")]
        internal uint CreatedInternal { get; set; }
        public DateTimeOffset Created => DateTimeOffset.FromUnixTimeSeconds(CreatedInternal);
        [JsonPropertyName("timestamp_updated")]
        public uint UpdatedRaw { get; set; }
        public DateTimeOffset Updated => DateTimeOffset.FromUnixTimeSeconds(UpdatedRaw);
        [JsonPropertyName("voted_up")]
        public bool VotedUp { get; set; }
        [JsonPropertyName("votes_up")]
        public uint VotesUp { get; set; }
        [JsonPropertyName("votes_funny")]
        public uint VotesFunny { get; set; }
        [JsonPropertyName("weighted_vote_score")]
        public string WeightedVoteScore { get; set; }
        [JsonPropertyName("comment_count")]
        public uint CommentCount { get; set; }
        [JsonPropertyName("steam_purchase")]
        public bool SteamPurchase { get; set; }
        [JsonPropertyName("received_for_free")]
        public bool ReceivedForFree { get; set; }
        [JsonPropertyName("written_during_early_access")]
        public bool WrittenDuringEarlyAccess { get; set; }
    }
}
