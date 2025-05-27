using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchModel = DesdeElBanquilloMaui.Models.Match;

namespace DesdeElBanquilloMaui.Services
{
    public class MatchService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Matches";

        public MatchService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<MatchModel>> GetMatchesAsync() => _apiService.GetAllAsync<MatchModel>(Endpoint);
        public Task<MatchModel?> GetMatchByIdAsync(int id) => _apiService.GetByIdAsync<MatchModel>(Endpoint, id);
        public Task<bool> CreateMatchAsync(MatchModel match) => _apiService.CreateAsync(Endpoint, match);
        public Task<bool> UpdateMatchAsync(int id, MatchModel match) => _apiService.UpdateAsync(Endpoint, id, match);
        public Task<bool> DeleteMatchAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
