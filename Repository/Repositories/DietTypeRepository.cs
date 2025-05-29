using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DietTypeRepository : IRepository<DietType>
    {
        private readonly IContext _context;

        public DietTypeRepository(IContext context)
        {
            this._context = context;
        }
        public DietType AddItem(DietType item)
        {
            this._context.DietTypes.Add(item);
            this._context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this._context.DietTypes.Remove(GetById(id));
            this._context.Save();
        }

        public List<DietType> GetAll()
        {
            return _context.DietTypes.ToList();
        }

        public DietType GetById(int id)
        {
            return _context.DietTypes.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void UpdateItem(int id, DietType item)
        {
            var dietType = GetById(id);
            dietType.DietName = item.DietName;
            dietType.TimeMeals = item.TimeMeals;
            dietType.MealsPerDay = item.MealsPerDay;
            dietType.NumCalories = item.NumCalories;
            dietType.Customers = item.Customers;

            _context.Save();

            dietType.TimeMealsString = item.TimeMealsString;

            //לבדק אם זה באמת כל הפרופרטי
            _context.Save();
        }
    }
}