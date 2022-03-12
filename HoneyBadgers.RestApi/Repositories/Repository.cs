using HoneyBadgers.RestApi.Context;
using HoneyBadgers.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.RestApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HbReportContext _context;
        private readonly DbSet<T> _entities;
        public Repository(HbReportContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _entities.AsQueryable();
        }

        public T Get(string id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
