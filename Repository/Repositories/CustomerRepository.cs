using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly List<Customer> _customers = new();
        private int _nextId = 1;

        public Customer AddItem(Customer item)
        {
            item.Id = _nextId++;
            _customers.Add(item);
            return item;
        }

        public void DeleteItem(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
                _customers.Remove(customer);
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id)!;
        }

        public void UpdateItem(int id, Customer item)
        {
            var index = _customers.FindIndex(c => c.Id == id);
            if (index != -1)
            {
                item.Id = id;
                _customers[index] = item;
            }
        }
    }
}
