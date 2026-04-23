using KoeretoejsManager.Interfaces;
using KoeretoejsManager.Models.HelperModels;

namespace KoeretoejsManager.Services
{
    public class UserAuthApiService : IUserAuthApiService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public UserAuthApiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            $"{_config["ApiBaseUrl"]}/api/auth/login");

            request.Headers.Add("X-Api-Key", _config["ApiKey"]);

            request.Content = JsonContent.Create(new
            {
                username,
                password
            });

            var response = await _http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<LoginRequestResponse>();

            return result?.AccessToken;
        }
    }
}
