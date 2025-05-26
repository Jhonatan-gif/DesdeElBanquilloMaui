using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class PlayerService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Players";

        public PlayerService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Player>> GetPlayersAsync() => _apiService.GetAllAsync<Player>(Endpoint);
        public Task<Player?> GetPlayerByIdAsync(int id) => _apiService.GetByIdAsync<Player>(Endpoint, id);
        public Task<bool> CreatePlayerAsync(Player player) => _apiService.CreateAsync(Endpoint, player);
        public Task<bool> UpdatePlayerAsync(int id, Player player) => _apiService.UpdateAsync(Endpoint, id, player);
        public Task<bool> DeletePlayerAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }

}
