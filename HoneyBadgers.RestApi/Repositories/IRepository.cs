using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.RestApi.Models;

namespace HoneyBadgers.RestApi.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable();
        T Get(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
