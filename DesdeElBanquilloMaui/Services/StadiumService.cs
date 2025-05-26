using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class StadiumService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Stadiums";

        public StadiumService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Stadium>> GetStadiumsAsync() => _apiService.GetAllAsync<Stadium>(Endpoint);
        public Task<Stadium?> GetStadiumByIdAsync(int id) => _apiService.GetByIdAsync<Stadium>(Endpoint, id);
        public Task<bool> CreateStadiumAsync(Stadium stadium) => _apiService.CreateAsync(Endpoint, stadium);
        public Task<bool> UpdateStadiumAsync(int id, Stadium stadium) => _apiService.UpdateAsync(Endpoint, id, stadium);
        public Task<bool> DeleteStadiumAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
