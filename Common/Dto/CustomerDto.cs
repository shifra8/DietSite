using Microsoft.AspNetCore.Http;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Dto
{
    public class CustomerDto
    {//מה שמוצג ללקוח
        public string Phone { get; set; }
        public string FullName { get; set; }
       // public string LastName { get; set; }
        public eRole Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        //public DietType DietType { get; set; } // שדה לדיאט טייפ (ולא string)
        public int Id { get; set; }
        public byte[]? ImagePath { get; set; }
        public IFormFile? fileImage { get; set; }

        //// פונקציה להמיר מ-CreateCustomerDto ל-CustomerDto
        //public static CustomerDto ToCustomerDto(CreateCustomerDto createCustomerDto, List<DietType> availableDietTypes)
        //{
        //    var dietType = GetDietTypeFromFoodIds(createCustomerDto.FavoriteFoodIds, availableDietTypes); // המרה לדיאט
        //    return new CustomerDto
        //    {
        //        FirstName = createCustomerDto.FirstName,
        //        LastName = createCustomerDto.LastName,
        //        Email = createCustomerDto.Email,
        //        Phone = createCustomerDto.Phone,
        //        Height = createCustomerDto.Height,
        //        Weight = createCustomerDto.Weight,
        //        DietType = dietType
        //    };
        //}

        //private static DietType GetDietTypeFromFoodIds(List<int> foodIds, List<DietType> availableDietTypes)
        //{
        //    // נניח שאתה מבצע חיפוש על מאכלים אהובים ומחליט על דיאט בהתאם
        //    // כאן אתה יכול להוסיף לוגיקה לפי הצורך (למשל אם אחד מהמאכלים שייך לדיאטה מסוימת)

        //    // דוגמה למימוש: חיפוש דיאטה על פי מזהים מהמאגר
        //    var diet = availableDietTypes.FirstOrDefault(d => foodIds.Contains(d.Id));
        //    if (diet != null)
        //    {
        //        return diet;
        //    }
        //    else
        //    {
        //        return availableDietTypes.FirstOrDefault(); // אם לא מצא דיאטה, מחזיר דיאטת ברירת מחדל
        //    }
       // }
    }
}
