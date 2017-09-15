using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity;

namespace Service
{
    public class UnitOfWork : IUnitOfWork
    {
        //   IDbSet<T> entity;
        private Dictionary<string, object> repositories;
        private readonly HRDbContext context;
        public UnitOfWork(HRDbContext context)
        {
            this.context = context;
        }
        public UnitOfWork()
        {
            //   context = new CurdDbContext();
        }
        public void Dispose()
        {
            this.Dispose();
        }
        public Repository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}