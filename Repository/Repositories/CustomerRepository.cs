using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Reposetories
{
    //V
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly IContext _context;
        public CustomerRepository(IContext _context)
        {
            this._context = _context;
        }
        public Customer AddItem(Customer item)
        {
            this._context.Customers.Add(item);
            this._context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this._context.Customers.Remove(GetById(id));
            this._context.Save();
        }


        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return this._context.Customers.FirstOrDefault(x => x.CustomerId == id);
        }


        public void UpdateItem(int id, Customer item)
        {
            var customer = GetById(id);
            customer.FullName = item.FullName;
            _context.Save();
        }

      
    }
}
