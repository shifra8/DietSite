using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IContext 
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DietType> DietTypes { get; set; }
        public DbSet<WeeklyTracking> WeeklyTrackings { get; set; }
        public DbSet<ProductForDietType> ProductForDietTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerFoodPreference> CustomerFoodPreferences { get; set; }

        public void Save();


    }
}
