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
            var quoteResponse = new ServiceResponse<Quote>();

            var response = await _httpClient.GetAsync("https://programming-quotes-api.herokuapp.com/Quotes/random");
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var quote = await JsonSerializer.DeserializeAsync<Quote>(responseStream);

            if (quote is null)
            {
                quoteResponse.Success = false;
                quoteResponse.Message = "No result";
            }
            else
            {
                quoteResponse.Data = quote;
            }

            return quoteResponse;
        }
    }
}
