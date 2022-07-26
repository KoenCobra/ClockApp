﻿using System.Text.Json;
using ClockApp.Models;
using ClockApp.Sdk.Abstractions;

namespace ClockApp.Sdk
{
    public class WorldTimeApi : IWorldTimeApi
    {
        private readonly HttpClient _httpClient;

        public WorldTimeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<CurrentTime>> GetCurrentTime()
        {
            var serviceResponse = new ServiceResponse<CurrentTime>();

            var response = await _httpClient.GetAsync("https://worldtimeapi.org/api/ip");
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var currentTime = await JsonSerializer.DeserializeAsync<CurrentTime>(responseStream);

            if (currentTime is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No result";
            }
            else
            {
                serviceResponse.Data = currentTime;
            }

            return serviceResponse;
        }
    }
}
