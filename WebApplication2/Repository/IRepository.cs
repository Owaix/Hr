using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Repository
{
    public interface IRepository<T>
    {
        void Create();
        T Update(Func<T, bool> where);
        IEnumerable<T> GetAll();
        void Delete(int id);
    }
}
