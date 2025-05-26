using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>($"{_baseUrl}/{endpoint}");
            return response ?? new List<T>();
        }

        public async Task<T?> GetByIdAsync<T>(string endpoint, int id)
        {
            return await _httpClient.GetFromJsonAsync<T>($"{_baseUrl}/{endpoint}/{id}");
        }

        public async Task<bool> CreateAsync<T>(string endpoint, T entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{endpoint}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync<T>(string endpoint, int id, T entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{endpoint}/{id}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string endpoint, int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
