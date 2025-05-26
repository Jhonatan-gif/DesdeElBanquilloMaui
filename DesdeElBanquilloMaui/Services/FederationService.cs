using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class FederationService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Federations";

        public FederationService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Federation>> GetFederationsAsync() => _apiService.GetAllAsync<Federation>(Endpoint);
        public Task<Federation?> GetFederationByIdAsync(int id) => _apiService.GetByIdAsync<Federation>(Endpoint, id);
        public Task<bool> CreateFederationAsync(Federation federation) => _apiService.CreateAsync(Endpoint, federation);
        public Task<bool> UpdateFederationAsync(int id, Federation federation) => _apiService.UpdateAsync(Endpoint, id, federation);
        public Task<bool> DeleteFederationAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }

}
