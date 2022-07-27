using ClockApp.Models;

namespace ClockApp.Sdk.Abstractions
{
    public interface IIpBaseApi
    {
        Task<ServiceResponse<IpBase>> GetIpBase(string ip);
    }
}
