using System;

namespace Pjatk.Tin.FitApp.Domain.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public NutritionalPlan NutritionalPlan { get; set; }
        public FoodDiary FoodDiary { get; set; }

    }
}
