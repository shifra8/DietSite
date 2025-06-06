using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFoodPreferenceRepository
    {
        void AddItem(CustomerFoodPreference pref);
        void DeleteByCustomerId(int customerId);
        List<CustomerFoodPreference> GetByCustomerId(int customerId);
    }
}
