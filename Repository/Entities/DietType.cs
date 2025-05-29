using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Repository.Entities
{
    public class DietType
    {
        [Key]
        public int Id { get; set; }
        public string DietName { get; set; }
        public int MealsPerDay { get; set; }
        public int NumCalories { get; set; }

        // מחרוזת המייצגת את תאריכי הארוחות
        public string TimeMealsString { get; set; }

        // מאפיין שלא יישמר בבסיס הנתונים
        [NotMapped]
        public List<DateTime> TimeMeals
        {
            get => TimeMealsString?.Split(',').Select(DateTime.Parse).ToList();
            set => TimeMealsString = value != null ? string.Join(",", value.Select(dt => dt.ToString("o"))) : null;
        }

        public string SpecialComments { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        //  public virtual ICollection<Product> Products { get; set; }
        public string? ImageUrl { get; set; }

    }
}