using Common.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Entities;
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
            // מוחקים את ההעדפות הקודמות
            _unitOfWork.FoodPreferenceRepository.DeleteByCustomerId(userId);

            // שומרים את המוצרים האהובים
            if (dto.LikedProducts != null)
            {
                foreach (var product in dto.LikedProducts)
                {
                    var pref = new CustomerFoodPreference
                    {
                        CustomerId = userId,
                        ProductId = product.ProductId
                        // אין צורך בשדה נוסף
                    };
                    _unitOfWork.FoodPreferenceRepository.AddItem(pref);
                }
            }

            // שומרים את המוצרים השנואים
            if (dto.DislikedProducts != null)
            {
                foreach (var product in dto.DislikedProducts)
                {
                    var pref = new CustomerFoodPreference
                    {
                        CustomerId = userId,
                        ProductId = product.ProductId
                        // אין צורך בשדה נוסף
                    };
                    _unitOfWork.FoodPreferenceRepository.AddItem(pref);
                }
            }

            _unitOfWork.Save();
        }


        public FoodPreferencesDto GetUserPreferences(int userId)
        {
            var preference = _unitOfWork.FoodPreferenceRepository.GetByCustomerId(userId);

            if (preference == null)
            {
                return new FoodPreferencesDto
                {
                    CustomerId = userId,
                    LikedProducts = new List<Product>(),
                    DislikedProducts = new List<Product>()
                };
            }

            return new FoodPreferencesDto
            {
                CustomerId = userId,
                LikedProducts = preference.LikedProducts ?? new List<Product>(),
                DislikedProducts = preference.DislikedProducts ?? new List<Product>()
            };
        }

        public void ClearPreferences(int userId)
        {
            // מחיקה/ניקוי מהמסד
        }
    }

}
