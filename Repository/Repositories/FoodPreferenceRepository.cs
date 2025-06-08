using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void DeleteByCustomerId(int customerId)
        {
            var prefs = _context.CustomerFoodPreferences
                .Where(p => p.CustomerId == customerId)
                .ToList();

            _context.CustomerFoodPreferences.RemoveRange(prefs);
        }

        

        //public List<CustomerFoodPreference> GetByCustomerId(int customerId)
        //{
        //    return _context.CustomerFoodPreferences
        //        .Where(p => p.CustomerId == customerId)
        //        .ToList();
        //}

        public CustomerFoodPreference GetByCustomerId(int userId)
        {
            var preference = _context.CustomerFoodPreferences
                .FirstOrDefault(p => p.CustomerId == userId);

            if (preference == null)
            {
                return new CustomerFoodPreference
                {
                    CustomerId = userId,
                    LikedProducts = new List<Product>(),
                    DislikedProducts = new List<Product>()
                };
            }

            return new CustomerFoodPreference
            {
                CustomerId = userId,
                LikedProducts = preference.LikedProducts ?? new List<Product>(),
                DislikedProducts = preference.DislikedProducts ?? new List<Product>()
            };
        }

    }
}