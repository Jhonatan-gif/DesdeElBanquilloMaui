using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class SeasonService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Seasons";

        public SeasonService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Season>> GetSeasonsAsync() => _apiService.GetAllAsync<Season>(Endpoint);
        public Task<Season?> GetSeasonByIdAsync(int id) => _apiService.GetByIdAsync<Season>(Endpoint, id);
        public Task<bool> CreateSeasonAsync(Season season) => _apiService.CreateAsync(Endpoint, season);
        public Task<bool> UpdateSeasonAsync(int id, Season season) => _apiService.UpdateAsync(Endpoint, id, season);
        public Task<bool> DeleteSeasonAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
