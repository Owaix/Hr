using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T FindById(Func<T, bool> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
        void Attach(T entity);
    }
}

