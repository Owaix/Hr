using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication2.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> _set;
        public DbContext _context;

        public Repository(DbContext Context)
        {
            _context = Context;
            _set = _context.Set<T>();
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<T> GetAll()
        {
            _context.
        }
        public T Update(Func<T, bool> where)
        {
            throw new NotImplementedException();
        }
    }
}