using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class CompetitionService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Competitions";

        public CompetitionService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Competition>> GetCompetitionsAsync() => _apiService.GetAllAsync<Competition>(Endpoint);
        public Task<Competition?> GetCompetitionByIdAsync(int id) => _apiService.GetByIdAsync<Competition>(Endpoint, id);
        public Task<bool> CreateCompetitionAsync(Competition competition) => _apiService.CreateAsync(Endpoint, competition);
        public Task<bool> UpdateCompetitionAsync(int id, Competition competition) => _apiService.UpdateAsync(Endpoint, id, competition);
        public Task<bool> DeleteCompetitionAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
