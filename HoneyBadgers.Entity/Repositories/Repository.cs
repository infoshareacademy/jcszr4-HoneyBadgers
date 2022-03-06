using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Entity.Context;
using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Entity.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly HbContext _context;
        private DbSet<T> entities;
        public Repository(HbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return entities.AsQueryable();
        }

        public T Get(string id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
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
            entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
