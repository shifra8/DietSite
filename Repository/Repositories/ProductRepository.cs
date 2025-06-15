using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductRepository : IRepository<Product>
{
    private readonly IContext _context;
    public ProductRepository(IContext context) => _context = context;

    public Product AddItem(Product item)
    {
        _context.Products.Add(item);
        _context.Save();
        return item;
    }

    public void DeleteItem(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.Save();
        }
    }

    public List<Product> GetAll() => _context.Products.ToList();

    public Product GetById(int id) => _context.Products.FirstOrDefault(p => p.ProductId == id);

    public void UpdateItem(int id, Product item)
    {
        var p = GetById(id);
        if (p != null)
        {
            p.Name = item.Name;
            p.Calories = item.Calories;
            p.Protein = item.Protein;
            p.Fat = item.Fat;
            p.Carbohydrates = item.Carbohydrates;
            p.SourceApi = item.SourceApi;
            _context.Save();
        }
    }
}

