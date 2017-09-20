using System;
using System.Collections.Generic;

namespace Service
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> FindById(Func<T, bool> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
        void Attach(T entity);
    }
}

