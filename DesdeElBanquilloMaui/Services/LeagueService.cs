using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class LeagueService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Leagues";

        public LeagueService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<League>> GetLeaguesAsync() => _apiService.GetAllAsync<League>(Endpoint);
        public Task<League?> GetLeagueByIdAsync(int id) => _apiService.GetByIdAsync<League>(Endpoint, id);
        public Task<bool> CreateLeagueAsync(League league) => _apiService.CreateAsync(Endpoint, league);
        public Task<bool> UpdateLeagueAsync(int id, League league) => _apiService.UpdateAsync(Endpoint, id, league);
        public Task<bool> DeleteLeagueAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
