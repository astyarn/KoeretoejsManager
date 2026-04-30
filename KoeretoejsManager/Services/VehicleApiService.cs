using KoeretoejsManager.Api.Models.HelperModels;
using KoeretoejsManager.Interfaces;
using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Services
{
    public class VehicleApiService : IVehicleApiService
    {

        private readonly HttpClient _http;
        private readonly string _apiKey;

        public VehicleApiService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("ApiKey missing");

            //Set default header for all requests using this HttpClient
            _http.DefaultRequestHeaders.Remove("x-api-key");
            _http.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }

        public async Task<List<VehicleSearchByDriverslicenseDTO>> GetAllVehicles()
        {
            return await _http.GetFromJsonAsync<List<VehicleSearchByDriverslicenseDTO>>("api/vehicle/all-vehicles");

        }

        public async Task<List<VehicleSearchByDriverslicenseDTO>> GetVehiclesByDrivingLicense(List<DrivingLicenseType> drivingLicenseTypes)
        {
            var request = new VehicleSearchDriversLicenseRequest
            {
                LicenseTypes = drivingLicenseTypes
            };

            var response = await _http.PostAsJsonAsync("api/vehicle/search-by-drivers-license", request);

            return await response.Content.ReadFromJsonAsync<List<VehicleSearchByDriverslicenseDTO>>();
        }

        public async Task<VehicleDTO?> CreateVehicle(CreateVehicleDTO dto)
        {
            var response = await _http.PostAsJsonAsync("api/vehicle/create", dto);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Vehicle creation failed: {error}");
            }

            return await response.Content.ReadFromJsonAsync<VehicleDTO>();
        }
    }
}
