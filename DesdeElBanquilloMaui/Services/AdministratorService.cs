using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class AdministratorService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Administrators";

        public AdministratorService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<Administrator>> GetAdministratorsAsync() => _apiService.GetAllAsync<Administrator>(Endpoint);
        public Task<Administrator?> GetAdministratorByIdAsync(int id) => _apiService.GetByIdAsync<Administrator>(Endpoint, id);
        public Task<bool> CreateAdministratorAsync(Administrator admin) => _apiService.CreateAsync(Endpoint, admin);
        public Task<bool> UpdateAdministratorAsync(int id, Administrator admin) => _apiService.UpdateAsync(Endpoint, id, admin);
        public Task<bool> DeleteAdministratorAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
