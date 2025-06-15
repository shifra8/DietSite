using Common.Dto;

namespace Service.Interfaces
{
    public interface IProductApiService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(string id);
    }
}
