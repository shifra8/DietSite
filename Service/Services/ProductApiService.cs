using Common.Dto;
using Service.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

//מסמך לדוגמה להתחברות לapi
namespace Service
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDto>>("https://api.example.com/products")
                   ?? new List<ProductDto>();
        }

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"https://api.example.com/products/{id}");
        }
    }
}
