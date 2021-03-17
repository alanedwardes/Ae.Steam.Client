using Ae.Steam.Client.Exceptions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ae.Steam.Client.Tests
{
    public class SteamClientTests
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public SteamClient _steamClient = new SteamClient(_httpClient);

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
            Assert.Null(appDetails.RequiredAge);
        }

        [Fact]
        public async Task TestGetAppDetailsEstrangedTheDeparture()
        {
            var appDetails = await _steamClient.GetAppDetails(582890, CancellationToken.None);

            Assert.Equal("Estranged: The Departure", appDetails.Name);
            Assert.Equal(582890u, appDetails.SteamAppId);
        }

        [Fact]
        public async Task TestGetAppList()
        {
            var appList = await _steamClient.GetAppList(CancellationToken.None);

            Assert.Contains(appList, x => x.AppId == 261820);
            Assert.Contains(appList, x => x.AppId == 289650);
            Assert.Contains(appList, x => x.AppId == 582890);
        }
    }
}
