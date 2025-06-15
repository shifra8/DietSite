using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using global::Service.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
namespace Service.Services
{
    public class ProductService : IService<ProductDto>
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public ProductDto AddItem(ProductDto dto)
        {
            var entity = MapToEntity(dto);
            var added = _repository.AddItem(entity);
            return MapToDto(added);
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<ProductDto> GetAll()
        {
            return _repository.GetAll()
                .Select(MapToDto)
                .ToList();
        }

        public ProductDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity == null ? null : MapToDto(entity);
        }

        public void UpdateItem(int id, ProductDto dto)
        {
            var entity = MapToEntity(dto);
            _repository.UpdateItem(id, entity);
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Calories = product.Calories,
                Protein = product.Protein,
                Fat = product.Fat,
                Carbohydrates = product.Carbohydrates,
                SourceApi = product.SourceApi
            };
        }

        private Product MapToEntity(ProductDto dto)
        {
            return new Product
            {
                ProductId = dto.ProductId ,
                Name = dto.Name ?? "",
                Calories = dto.Calories,
                Protein = dto.Protein,
                Fat = dto.Fat,
                Carbohydrates = dto.Carbohydrates,
                SourceApi = dto.SourceApi
            };
        }
    }
}

