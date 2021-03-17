using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamAppList
    {
        [JsonPropertyName("apps")]
        public IReadOnlyList<SteamAppSummary> Apps { get; set; } = new SteamAppSummary[0];
    }
}
