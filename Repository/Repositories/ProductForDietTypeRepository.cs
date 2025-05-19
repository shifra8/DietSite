using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Reposetories
{
 
    public class ProductForDietTypeRepository : IRepository<ProductForDietType>
    {
        private readonly IContext _context;
        public ProductForDietTypeRepository(IContext _context)
        {
            this._context = _context;
        }
        public ProductForDietType AddItem(ProductForDietType item)
        {
            this._context.ProductForDietTypes.Add(item);
            this._context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this._context.ProductForDietTypes.Remove(GetById(id));
            this._context.Save();
        }


        public List<ProductForDietType> GetAll()
        {
            return _context.ProductForDietTypes.ToList();
        }

        public ProductForDietType GetById(int id)
        {
            return this._context.ProductForDietTypes.FirstOrDefault(x => x.Id.Equals(id));
        }


        public void UpdateItem(int id, ProductForDietType item)
        {
            var productForDietType = GetById(id);
            productForDietType.ProdName = item.ProdName;
            _context.Save();
        }


    }
}
