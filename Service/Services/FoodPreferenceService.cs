﻿using Common.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FoodPreferenceService : IFoodPreferenceService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FoodPreferenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveUserPreferences(FoodPreferencesDto dto, int userId)
        {
            // כאן מבצעים שמירה למסד נתונים דרך ה-Repository
        }

        public FoodPreferencesDto GetUserPreferences(int userId)
        {
            // שליפה מהמסד
        }

        public void ClearPreferences(int userId)
        {
            // מחיקה/ניקוי מהמסד
        }
    }

}
