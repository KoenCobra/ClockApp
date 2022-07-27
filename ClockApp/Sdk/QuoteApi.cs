using System.Text.Json;
using ClockApp.Models;
using ClockApp.Sdk.Abstractions;

namespace ClockApp.Sdk
{
    public class QuoteApi : IQuoteApi
    {
        private readonly HttpClient _httpClient;

        public QuoteApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Quote>> GetQuote()
        {
            var serviceResponse = new ServiceResponse<Quote>();

            var response = await _httpClient.GetAsync("https://programming-quotes-api.herokuapp.com/Quotes/random");
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var quote = await JsonSerializer.DeserializeAsync<Quote>(responseStream);

            if (quote is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No result";
            }
            else
            {
                serviceResponse.Data = quote;
            }

            return serviceResponse;
        }
    }
}
