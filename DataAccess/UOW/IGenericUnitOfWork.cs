using System.Data.Entity;
using LT.QMS.Common.Entities;
using LT.QMS.DAL.Repository;

namespace LT.QMS.DAL.UOW
{
    public interface IGenericUnitOfWork
    {
        DbContext Context { get; }

        void Dispose();
        IRepository<T> Repository<T>() where T : BaseEntity;
        void SaveChanges();
    }
}