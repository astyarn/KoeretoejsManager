using KoeretoejsManager.Interfaces;
using KoeretoejsManager.Models.HelperModels;

namespace KoeretoejsManager.Services
{
    public class UserAuthApiService : IUserAuthApiService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;
        private readonly IUserTokenStore _userTokenStore;

        public UserAuthApiService(HttpClient http, IConfiguration config, IUserTokenStore userTokenStore)
        {
            _http = http;
            _config = config;
            _userTokenStore = userTokenStore;
        }

        public async Task<bool?> LoginAsync(string username, string password)
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

            if (result == null)
                return false;

            var expiresAt = DateTime.UtcNow.AddSeconds(result.ExpiresIn);

            await _userTokenStore.SetTokenAsync(result.AccessToken, expiresAt);

            return true;
        }
    }
}
