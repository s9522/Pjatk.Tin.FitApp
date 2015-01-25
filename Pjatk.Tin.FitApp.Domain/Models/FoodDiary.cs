using System.Collections.Generic;

namespace Pjatk.Tin.FitApp.Domain.Models
{
    public class FoodDiary : Diary<FoodDiaryItem>
    {
        private IList<FoodDiaryItem> _diaryItem; 
        public override IList<FoodDiaryItem> DiaryItems
        {
            get { return _diaryItem ?? (_diaryItem = new List<FoodDiaryItem>()); }
        }
    }
}
