using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class LeagueTableService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "LeagueTables";

        public LeagueTableService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<LeagueTable>> GetLeagueTablesAsync() => _apiService.GetAllAsync<LeagueTable>(Endpoint);
        public Task<LeagueTable?> GetLeagueTableByIdAsync(int id) => _apiService.GetByIdAsync<LeagueTable>(Endpoint, id);
        public Task<bool> CreateLeagueTableAsync(LeagueTable leagueTable) => _apiService.CreateAsync(Endpoint, leagueTable);
        public Task<bool> UpdateLeagueTableAsync(int id, LeagueTable leagueTable) => _apiService.UpdateAsync(Endpoint, id, leagueTable);
        public Task<bool> DeleteLeagueTableAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}

