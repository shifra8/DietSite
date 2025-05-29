using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class FoodPreferencesDto
    {
       
            public int CustomerId { get; set; }

            public List<string> LikedProducts { get; set; }

            public List<string> DislikedProducts { get; set; }
        }

    
}
