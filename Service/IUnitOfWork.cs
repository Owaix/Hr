using CF.Repo;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IUnitOfWork : IDisposable
    {
        void Save();
        Repository<T> Repository<T>() where T : BaseEntity;
    }
}
