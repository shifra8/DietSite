using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class FoodPreferencesDto
    {

            public int Id { get; set; }

            public int CustomerId { get; set; }

            public List<Product> LikedProducts { get; set; }

            public List<Product> DislikedProducts { get; set; }
        }

    
}
