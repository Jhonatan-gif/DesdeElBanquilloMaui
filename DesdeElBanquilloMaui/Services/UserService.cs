using DesdeElBanquilloMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class UserService
    {
        private readonly ApiService _apiService;
        private const string Endpoint = "Users";

        public UserService()
        {
            _apiService = new ApiService("https://localhost:7135/api");
        }

        public Task<List<User>> GetUsersAsync() => _apiService.GetAllAsync<User>(Endpoint);
        public Task<User?> GetUserByIdAsync(int id) => _apiService.GetByIdAsync<User>(Endpoint, id);
        public Task<bool> CreateUserAsync(User user) => _apiService.CreateAsync(Endpoint, user);
        public Task<bool> UpdateUserAsync(int id, User user) => _apiService.UpdateAsync(Endpoint, id, user);
        public Task<bool> DeleteUserAsync(int id) => _apiService.DeleteAsync(Endpoint, id);
    }
}
