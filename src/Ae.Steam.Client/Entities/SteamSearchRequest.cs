using System.Collections.Generic;

namespace Ae.Steam.Client.Entities
{
    public class SteamSearchRequest
    {
        public string? Term { get; set; }
        public uint Start { get; set; } = 0;
        public uint Count { get; set; } = 50;
        public ISet<SteamSearchTags> Tags { get; set; } = new HashSet<SteamSearchTags>();
    }
}
