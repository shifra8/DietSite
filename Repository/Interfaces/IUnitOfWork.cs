using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IFoodPreferenceRepository FoodPreferenceRepository { get; }
        void Save(); // או SaveChanges, תלוי במימוש שלך
    }
}
