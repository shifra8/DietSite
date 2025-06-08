using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;

namespace Repository.Entities
{

    //public enum FoodPreferenceType
    //{
    //    LIKE,
    //    DISLIKE
    //}

    public class CustomerFoodPreference
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Required]
        public string ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public List<Product> LikedProducts { get; set; }

        public List<Product> DislikedProducts { get; set; }
        // [Required]
        //   public FoodPreferenceType PreferenceType { get; set; }
    }
}
