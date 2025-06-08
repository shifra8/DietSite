
using Microsoft.AspNetCore.Http;
using Repository.Entities;
using System.Collections.Generic;

namespace Common.Dto
{
    public class SignUpDto
    {
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public eRole Role { get; set; }

        //לבדק שורה זו
        public CustomerFoodPreference FavoriteFoodIds { get; set; } //מאכלים אהובים
        //public List<int> GroupIds { get; set; } //  ללקוח (או המשתמש) יש רשימת מזהים של קבוצות שהוא שייך אליהן.
    }
}