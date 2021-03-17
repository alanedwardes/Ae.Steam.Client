using System;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamReviewAuthor
    {
        [JsonPropertyName("steamid")]
        public string SteamId { get; set; }
        [JsonPropertyName("num_games_owned")]
        public uint NumGamesOwned { get; set; }
        [JsonPropertyName("num_reviews")]
        public uint NumReviews { get; set; }
        [JsonPropertyName("playtime_forever")]
        public uint PlaytimeForeverRaw { get; set; }
        public TimeSpan PlayTimeForever => TimeSpan.FromMinutes(PlaytimeForeverRaw);
        [JsonPropertyName("playtime_last_two_weeks")]
        public uint PlayTimeLastTwoWeeksRaw { get; set; }
        public TimeSpan PlayTimeLastTwoWeeks => TimeSpan.FromMinutes(PlayTimeLastTwoWeeksRaw);
        [JsonPropertyName("last_played")]
        public uint LastPlayedRaw { get; set; }
        public DateTimeOffset LastPlayed => DateTimeOffset.FromUnixTimeSeconds(LastPlayedRaw);
    }
}
