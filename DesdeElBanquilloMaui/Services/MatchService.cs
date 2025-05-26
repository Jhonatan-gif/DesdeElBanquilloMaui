using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public Task<List<Match>> GetMatchesAsync() => _apiService.GetAllAsync<Match>(Endpoint);
        public Task<Match?> GetMatchByIdAsync(int id) => _apiService.GetByIdAsync<Match>(Endpoint, id);
        public Task<bool> CreateMatchAsync(Match match) => _apiService.CreateAsync(Endpoint, match);
        public Task<bool> UpdateMatchAsync(int id, Match match) => _apiService.UpdateAsync(Endpoint, id, match);
        public Task<bool> DeleteMatchAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }

}
