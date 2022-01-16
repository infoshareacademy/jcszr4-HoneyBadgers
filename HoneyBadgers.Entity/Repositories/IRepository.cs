using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Entity.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable();
        T Get(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
