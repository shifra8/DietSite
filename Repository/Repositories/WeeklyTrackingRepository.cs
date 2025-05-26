using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class WeeklyTrackingRepository : IRepository<WeeklyTracking>
    {
        private readonly IContext _context;

        public WeeklyTrackingRepository(IContext context)
        {
            this._context = context;
        }
        public WeeklyTracking AddItem(WeeklyTracking item)
        {
            this._context.WeeklyTrackings.Add(item);
            this._context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this._context.WeeklyTrackings.Remove(GetById(id));
            this._context.Save();
        }

        public List<WeeklyTracking> GetAll()
        {
            return _context.WeeklyTrackings.ToList();
        }

        public WeeklyTracking GetById(int id)
        {
            return _context.WeeklyTrackings.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void UpdateItem(int id, WeeklyTracking item)
        {
            var WeeklyTracking = GetById(id);
            WeeklyTracking.CustId = item.CustId;
            WeeklyTracking.WeekDate = item.WeekDate;
            WeeklyTracking.IsPassCalories = item.IsPassCalories;
            WeeklyTracking. UpdatdedWieght = item.UpdatdedWieght;
            _context.Save();
            //לבדק אם זה באמת כל הפרופרטי
        }
    }
}
