using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    namespace Common.Dto
    {
        public class FoodPreferencesDto
        {
            public int CustomerId { get; set; }
            //שמירת מוצרים עפ"י id
            public List<int> LikedProductIds { get; set; }

            public List<int> DislikedProductIds { get; set; }
        }
    }



}
