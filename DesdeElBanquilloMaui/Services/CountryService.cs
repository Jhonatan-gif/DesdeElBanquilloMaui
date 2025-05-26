using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class CountryService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Countries";

        public CountryService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Country>> GetCountriesAsync() => _apiService.GetAllAsync<Country>(Endpoint);
        public Task<Country?> GetCountryByIdAsync(int id) => _apiService.GetByIdAsync<Country>(Endpoint, id);
        public Task<bool> CreateCountryAsync(Country country) => _apiService.CreateAsync(Endpoint, country);
        public Task<bool> UpdateCountryAsync(int id, Country country) => _apiService.UpdateAsync(Endpoint, id, country);
        public Task<bool> DeleteCountryAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
