using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class FoodPreferenceRepository : IFoodPreferenceRepository
    {
        private readonly IContext _context;

        public FoodPreferenceRepository(IContext context)
        {
            _context = context;
        }

        public void AddItem(CustomerFoodPreference pref)
        {
            _context.CustomerFoodPreferences.Add(pref);
            _context.Save();
        }

        public void DeleteByCustomerId(int customerId)
        {
            var prefs = _context.CustomerFoodPreferences
                .Where(p => p.CustomerId == customerId)
                .ToList();

            _context.CustomerFoodPreferences.RemoveRange(prefs);
            _context.Save();
        }

        public List<CustomerFoodPreference> GetByCustomerId(int customerId)
        {
            return _context.CustomerFoodPreferences
                .Where(p => p.CustomerId == customerId)
                .ToList();
        }
    }
}
