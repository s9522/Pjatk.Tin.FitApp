﻿namespace Pjatk.Tin.FitApp.Domain.Models
{
    public class FoodProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public uint CaloriesPerGram { get; set; }
        public uint CarbsPerGram { get; set; }
        public uint FatPerGram { get; set; }
        public uint ProteinPerGram { get; set; }
    }
}
