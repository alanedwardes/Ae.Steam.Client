﻿using Ae.Steam.Client.Entities;
using Ae.Steam.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Steam.Client
{
    public sealed class SteamClient : ISteamClient
    {
        private readonly HttpClient _httpClient;

        public SteamClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Obsolete("This is not an official API. Do not use for critical applications.")]
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
    }
}