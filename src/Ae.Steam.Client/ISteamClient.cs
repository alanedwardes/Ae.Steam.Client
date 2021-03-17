using Ae.Steam.Client.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Steam.Client
{
    public interface ISteamClient
    {
        Task<SteamAppDetails> GetAppDetails(uint appId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SteamAppSummary>> GetAppList(CancellationToken cancellationToken);
    }
}