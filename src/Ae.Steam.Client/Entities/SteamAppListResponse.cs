using System.Text.Json.Serialization;

namespace Ae.Steam.Client.Entities
{
    public class SteamAppListResponse
    {
        [JsonPropertyName("applist")]
        public SteamAppList AppList { get; set; } = new SteamAppList();
    }
}
