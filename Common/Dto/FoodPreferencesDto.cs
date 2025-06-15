namespace Common.Dto
{
    public class FoodPreferencesDto
    {
        public int CustomerId { get; set; }
        public List<int> LikedProductIds { get; set; } = new();
        public List<int> DislikedProductIds { get; set; } = new();
    }
}
