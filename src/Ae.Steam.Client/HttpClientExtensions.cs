using Ae.Steam.Client.Exceptions;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ae.Steam.Client
{
    internal static class HttpClientExtensions
    {
        public static async Task<string> GetString(this HttpClient httpClient, string uri, CancellationToken cancellationToken)
        {
            try
            {
                var response = await httpClient.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw new SteamClientException($"Request failed to GET {uri}", e);
            }
        }

        public static async Task<T> GetJson<T>(this HttpClient httpClient, string uri, CancellationToken cancellationToken) where T : class
        {
            Stream stream;
            try
            {
                var response = await httpClient.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                stream = await response.Content.ReadAsStreamAsync();
            }
            catch (Exception e)
            {
                throw new SteamClientException($"Request failed to GET {uri}", e);
            }

            T? data;
            try
            {
                data = await JsonSerializer.DeserializeAsync<T>(stream, cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                throw new SteamClientException($"Unable to deserialise response from GET {uri}", e);
            }

            if (data == null)
            {
                throw new SteamClientException($"Unable to deserialise response from GET {uri}");
            }

            return data;
        }
    }
}
