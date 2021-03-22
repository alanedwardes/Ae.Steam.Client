using Ae.Steam.Client.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Steam.Client
{
    public interface ISteamClient
    {
        [Obsolete(SteamClient.ObsoleteWarning)]
        Task<SteamAppDetails> GetAppDetails(uint appId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SteamAppSummary>> GetAppList(CancellationToken cancellationToken);
        Task<SteamReviewsResponse> GetAppReviews(SteamReviewsRequest request, CancellationToken cancellationToken);
        [Obsolete(SteamClient.ObsoleteWarning)]
        Task<IReadOnlyList<SteamAppSummary>> SearchApps(SteamSearchRequest request, CancellationToken cancellationToken);
        [Obsolete(SteamClient.ObsoleteWarning)]
        Task<bool> IsAppAdultOnly(uint appId, CancellationToken cancellationToken);
    }
}