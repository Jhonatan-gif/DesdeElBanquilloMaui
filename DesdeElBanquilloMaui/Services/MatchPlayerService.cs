using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class MatchPlayerService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "MatchPlayers";

        public MatchPlayerService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<MatchPlayer>> GetMatchPlayersAsync() => _apiService.GetAllAsync<MatchPlayer>(Endpoint);
        public Task<MatchPlayer?> GetMatchPlayerByIdAsync(int id) => _apiService.GetByIdAsync<MatchPlayer>(Endpoint, id);
        public Task<bool> CreateMatchPlayerAsync(MatchPlayer matchPlayer) => _apiService.CreateAsync(Endpoint, matchPlayer);
        public Task<bool> UpdateMatchPlayerAsync(int id, MatchPlayer matchPlayer) => _apiService.UpdateAsync(Endpoint, id, matchPlayer);
        public Task<bool> DeleteMatchPlayerAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
