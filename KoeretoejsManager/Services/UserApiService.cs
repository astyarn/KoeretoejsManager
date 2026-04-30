using KoeretoejsManager.Interfaces;
using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public UserApiService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("ApiKey missing");

            //Set default header for all requests using this HttpClient
            _http.DefaultRequestHeaders.Remove("x-api-key");
            _http.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }

        public async Task<List<UserIdDTO>> GetAllUserIds()
        {
            return await _http.GetFromJsonAsync<List<UserIdDTO>>("api/user/all-user-ids");
        }
    }
}
