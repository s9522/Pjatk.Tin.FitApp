using System;
using System.Collections.Generic;
using System.Linq;

namespace Pjatk.Tin.FitApp.Domain.Models
{
    public abstract class Diary<T> where  T : DiaryItem
    {
        public abstract IList<T> DiaryItems { get; }

        public virtual void AddItem(T item)
        {
            if (DiaryItems.SingleOrDefault(i => i.Date == item.Date)==null)
            {
                DiaryItems.Add(item);
            }
            else
            {
                throw new ArgumentException("Diary item with date="+ item.Date +" already exists!", "item");
            }
        }

        public virtual void RemoveItem(T item)
        {
            if (DiaryItems.Contains(item))
            {
                DiaryItems.Remove(item);
            }
        }

        public virtual T GetItem(DateTime date)
        {
            return DiaryItems.SingleOrDefault(item => item.Date == date);
        }
    }
}