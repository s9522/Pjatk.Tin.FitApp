using System.Collections.Generic;
using System.Linq;

namespace Pjatk.Tin.FitApp.Domain.Models
{
    public class FoodDiaryItem : DiaryItem
    {
        public uint CaloriesConsumed
        {
            get { return (uint) FoodProductConsumed.Sum(a=>a.FoodProduct.CaloriesPerGram); }
        }

        public uint CarbsConsumed
        {
            get { return (uint)FoodProductConsumed.Sum(a => a.FoodProduct.CarbsPerGram); }
        }

        public uint FatConsumed
        {
            get { return (uint)FoodProductConsumed.Sum(a => a.FoodProduct.FatPerGram); }
        }

        public uint ProteinConsumed
        {
            get { return (uint)FoodProductConsumed.Sum(a => a.FoodProduct.ProteinPerGram); }
        }

        public IList<FoodProductConsumption> FoodProductConsumed { get; set; }
    }
}
