using Common.Dto;
using Common.Dto.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFoodPreferenceService
    {
      
        
            void SaveUserPreferences(FoodPreferencesDto dto, int userId);
            FoodPreferencesDto GetUserPreferences(int userId);
            void ClearPreferences(int userId);
        }


    
}
