using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pjatk.Tin.FitApp.Domain.Models;
using Raven.Client;

namespace Pjatk.Tin.FitApp.Domain.Services
{
    public abstract class BaseService<T> where T : Entity
    {
        public IDocumentSession DocumentSession { get; set; }

        public virtual T Find(T entity)
        {
            return DocumentSession.Load<T>(entity.Id);
        }

        public virtual T Find(string id)
        {
            return DocumentSession.Load<T>(id);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return DocumentSession.Query<T>().ToList();
        }

        public virtual void Add(T entity)
        {
            DocumentSession.Store(entity);
        }

        public virtual void Remove(T entity)
        {
            DocumentSession.Delete(entity);
        }
    }
}
