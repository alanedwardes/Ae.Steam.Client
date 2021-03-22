using Ae.Steam.Client.Entities;
using Ae.Steam.Client.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ae.Steam.Client.Tests
{
    public class SteamClientTests
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public ISteamClient _steamClient = new SteamClient(_httpClient);

        [Fact]
        public async Task TestGetAppDetailsNotFound()
        {
            await Assert.ThrowsAsync<SteamClientException>(() => _steamClient.GetAppDetails(uint.MaxValue, CancellationToken.None));
        }

        [Fact]
        public async Task TestGetAppDetailsEstrangedActI()
        {
            var appDetails = await _steamClient.GetAppDetails(261820, CancellationToken.None);

            Assert.Equal("Estranged: Act I", appDetails.Name);
            Assert.Equal(261820u, appDetails.SteamAppId);
        }

        [Fact]
        public async Task TestGetAppDetailsAssassinsCreedUnity()
        {
            var appDetails = await _steamClient.GetAppDetails(289650, CancellationToken.None);

            Assert.Equal("Assassin's Creed® Unity", appDetails.Name);
            Assert.Equal(289650u, appDetails.SteamAppId);
        }

        [Fact]
        public async Task TestGetAppDetailsDoom()
        {
            var appDetails = await _steamClient.GetAppDetails(379720, CancellationToken.None);

            Assert.Equal("DOOM", appDetails.Name);
            Assert.Equal(379720u, appDetails.SteamAppId);
            Assert.InRange(appDetails.RequiredAge.Value, 17u, 18u);
        }

        [Fact]
        public async Task TestGetAppDetailsEstrangedTheDeparture()
        {
            var appDetails = await _steamClient.GetAppDetails(582890, CancellationToken.None);

            Assert.Equal("Estranged: The Departure", appDetails.Name);
            Assert.Equal(582890u, appDetails.SteamAppId);
        }

        [Fact(Skip = "Non-deterministic")]
        public async Task TestGetAppList()
        {
            var appList = await _steamClient.GetAppList(CancellationToken.None);

            var appIds = appList.Select(x => x.AppId).ToArray();

            Assert.Contains(261820u, appIds);
            Assert.Contains(289650u, appIds);
            Assert.Contains(379720u, appIds);
            Assert.Contains(582890u, appIds);
        }

        [Fact]
        public async Task TestGetAppReviews()
        {
            var appReviews = await _steamClient.GetAppReviews(new SteamReviewsRequest(582890), CancellationToken.None);
        }

        [Fact]
        public async Task TestSearchApps()
        {
            var appResults = await _steamClient.SearchApps(new SteamSearchRequest{Term = "estranged"}, CancellationToken.None);

            Assert.Contains(appResults, x => x.AppId == 261820u);
            Assert.Contains(appResults, x => x.AppId == 582890u);
        }

        [Fact]
        public async Task TestIsAppAdultOnly()
        {
            Assert.False(await _steamClient.IsAppAdultOnly(582890, CancellationToken.None));
            Assert.True(await _steamClient.IsAppAdultOnly(1131990, CancellationToken.None));
        }
    }
}
