using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class PositionService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Positions";

        public PositionService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Position>> GetPositionsAsync() => _apiService.GetAllAsync<Position>(Endpoint);
        public Task<Position?> GetPositionByIdAsync(int id) => _apiService.GetByIdAsync<Position>(Endpoint, id);
        public Task<bool> CreatePositionAsync(Position position) => _apiService.CreateAsync(Endpoint, position);
        public Task<bool> UpdatePositionAsync(int id, Position position) => _apiService.UpdateAsync(Endpoint, id, position);
        public Task<bool> DeletePositionAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
