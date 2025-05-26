using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class TeamService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Teams";

        public TeamService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Team>> GetTeamsAsync() => _apiService.GetAllAsync<Team>(Endpoint);
        public Task<Team?> GetTeamByIdAsync(int id) => _apiService.GetByIdAsync<Team>(Endpoint, id);
        public Task<bool> CreateTeamAsync(Team team) => _apiService.CreateAsync(Endpoint, team);
        public Task<bool> UpdateTeamAsync(int id, Team team) => _apiService.UpdateAsync(Endpoint, id, team);
        public Task<bool> DeleteTeamAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
