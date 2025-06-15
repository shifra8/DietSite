using Common.Dto;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            if (dto.LikedProductIds != null)
            {
                foreach (var productId in dto.LikedProductIds)
                {
                    var pref = new CustomerFoodPreference
                    {
                        CustomerId = userId,
                        ProductId = productId,
                        IsLiked = true
                    };
                    _unitOfWork.FoodPreferenceRepository.AddItem(pref);
                }
            }

            // שומרים את המוצרים השנואים
            if (dto.DislikedProductIds != null)
            {
                foreach (var productId in dto.DislikedProductIds)
                {
                    var pref = new CustomerFoodPreference
                    {
                        CustomerId = userId,
                        ProductId = productId,
                        IsLiked = false
                    };
                    _unitOfWork.FoodPreferenceRepository.AddItem(pref);
                }
            }

            _unitOfWork.Save();
        }

        public FoodPreferencesDto GetUserPreferences(int userId)
        {
            var preferences = _unitOfWork.FoodPreferenceRepository.GetByCustomerId(userId);

            if (preferences == null || !preferences.Any())
            {
                return new FoodPreferencesDto
                {
                    CustomerId = userId,
                    LikedProductIds = new List<int>(),
                    DislikedProductIds = new List<int>()
                };
            }

            var liked = preferences.Where(p => p.IsLiked).Select(p => p.ProductId).ToList();
            var disliked = preferences.Where(p => !p.IsLiked).Select(p => p.ProductId).ToList();

            return new FoodPreferencesDto
            {
                CustomerId = userId,
                LikedProductIds = liked,
                DislikedProductIds = disliked
            };
        }

        public void ClearPreferences(int userId)
        {
            _unitOfWork.FoodPreferenceRepository.DeleteByCustomerId(userId);
            _unitOfWork.Save();
        }
    }
}
