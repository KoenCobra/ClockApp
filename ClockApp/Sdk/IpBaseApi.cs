using System.Text.Json;
using ClockApp.Models;
using ClockApp.Sdk.Abstractions;

namespace ClockApp.Sdk
{
    public class IpBaseApi : IIpBaseApi
    {
        private readonly HttpClient _httpClient;

        public IpBaseApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<IpBase>> GetIpBase(string ip)
        {
            var serviceResponse = new ServiceResponse<IpBase>();

            var response = await _httpClient.GetAsync($"https://api.ipbase.com/v2/info?apikey=A18KMLZAPB3xrreMkTX83lIYxKYMJch3IftKWHPY&ip={ip}");
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var ipBase = await JsonSerializer.DeserializeAsync<IpBase>(responseStream);

            if (ipBase is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No result";
            }
            else
            {
                serviceResponse.Data = ipBase;
            }

            return serviceResponse;
        }
    }
}
