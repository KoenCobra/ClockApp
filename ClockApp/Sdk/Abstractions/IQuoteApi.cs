using ClockApp.Models;

namespace ClockApp.Sdk.Abstractions
{
    public interface IQuoteApi
    {
        Task<ServiceResponse<Quote>> GetQuote();
    }
}
