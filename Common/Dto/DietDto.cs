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
