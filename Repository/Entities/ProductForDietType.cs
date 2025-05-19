using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ProductForDietType
    {
        [Key]
        public int Id { get; set; }
        public string ProdName { get; set; }
        public int DietTypeId { get; set; }
        [ForeignKey("dietTypeCode")]
        public DietType DietTypeCode { get; set; }
        //public Product ProductId { get; set; }צריך להתקשר לטבלת מוצרים המוכנה
    }
}
