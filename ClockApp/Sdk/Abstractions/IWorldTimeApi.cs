using ClockApp.Models;

namespace ClockApp.Sdk.Abstractions
{
    public interface IWorldTimeApi
    {
        Task<ServiceResponse<CurrentTime>> GetCurrentTime();
    }
}
