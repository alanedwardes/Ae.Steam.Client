using Ae.Steam.Client.Entities;
using Ae.Steam.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Steam.Client
{
    public sealed class SteamClient : ISteamClient
    {
        public const string ObsoleteWarning = "This is not an official API. Do not use for critical applications.";
        private readonly Regex storeUrlRegex = new Regex("/app/(?<Id>[0-9]*)/(?<Name>.*?)/");

        private readonly HttpClient _httpClient;

        public SteamClient(HttpClient httpClient) => _httpClient = httpClient;

        [Obsolete(ObsoleteWarning)]
        public async Task<SteamAppDetails> GetAppDetails(uint appId, CancellationToken cancellationToken)
        {
            var uri = $"https://store.steampowered.com/api/appdetails/?appids={appId}";
            var apps = await _httpClient.GetJson<IReadOnlyDictionary<uint, SteamAppDetailsResponse>>(uri, cancellationToken);

            var app = apps[appId];
            if (!app.Success || app.Data == null)
            {
                throw new SteamClientException($"Unable to get details for app {appId}. Check that it is a valid, public app.");
            }

            return app.Data;
        }

        public async Task<IReadOnlyList<SteamAppSummary>> GetAppList(CancellationToken cancellationToken)
        {
            var uri = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";
            var response = await _httpClient.GetJson<SteamAppListResponse>(uri, cancellationToken);
            return response.AppList.Apps;
        }

        [Obsolete(ObsoleteWarning)]
        public async Task<SteamReviewsResponse> GetAppReviews(SteamReviewsRequest request, CancellationToken cancellationToken)
        {
            // https://partner.steamgames.com/doc/store/getreviews
            var uri = $"http://store.steampowered.com/appreviews/{request.AppId}?json=1" +
                      $"&filter={request.Filter.ToString().ToLower()}" +
                      $"&language={request.Language}" +
                      $"&review_type={request.ReviewType.ToString().ToLower()}" +
                      $"&purchase_type={request.PurchaseType.ToString().ToLower()}" +
                      (request.DayRange.HasValue ? $"&day_range={request.DayRange.Value}" : string.Empty) +
                      (request.StartOffset.HasValue ? $"&start_offset={request.StartOffset.Value}" : string.Empty);
            return await _httpClient.GetJson<SteamReviewsResponse>(uri, cancellationToken);
        }

        public async Task<IReadOnlyList<SteamAppSummary>> SearchApps(SteamSearchRequest request, CancellationToken cancellationToken)
        {
            var options = new Dictionary<string, string>();

            if (request.Term != null)
            {
                options.Add("term", request.Term);
            }

            options.Add("start", request.Start.ToString());
            options.Add("count", request.Count.ToString());

            if (request.Tags.Any())
            {
                options.Add("tags", string.Join(",", request.Tags.Select(x => (uint)x)));
            }

            var uri = $"https://store.steampowered.com/search/results" +
                (options.Any() ? "?" + string.Join("&", options.Select(x => $"{x.Key}={x.Value}")) : null);

            var result = await _httpClient.GetString(uri, cancellationToken);

            var matches = storeUrlRegex.Matches(result);

            return matches.Cast<Match>().Select(x => new SteamAppSummary
            {
                AppId = uint.Parse(x.Groups["Id"].Value),
                Name = x.Groups["Name"].Value.Replace("_", " ")
            }).ToArray();
        }
    }
}
