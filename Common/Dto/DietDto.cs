﻿using Microsoft.AspNetCore.Http;

namespace Common.Dto
{
    public class DietDto
    {
        public int DietId { get; set; }
        public string DietName { get; set; }
        public int MealsPerDay { get; set; }
        public int NumCalories { get; set; }
        public string SpecialComments { get; set; }
        public string TimeMealsString { get; set; }

        public IFormFile? fileImage { get; set; } // התמונה שמועלת ע"י המשתמש
       // public string? ImagePath { get; set; }    // הנתיב לתמונה כפי שנשמר
        public string? ImageUrl { get; set; } // במקום ImagePath


        // המרה מ-DietType ל-DietDto
        //public static DietDto FromEntity(Repository.Entities.DietType dietType)
        //{
        //    return new DietDto
        //    {
        //        DietId = dietType.Id,
        //        DietName = dietType.NameDiet,
        //        MealsPerDay = dietType.NumMeal,
        //        DailyCalories = dietType.NumCalories,
        //        SpecialNotes = dietType.SpecialComments
        //    };
        //}
    }
}