using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HRDbContext : DbContext
    {
        public HRDbContext() : base("name=HRMSCOnStr")
        {
        }
        public DbSet<Employee> employee { get; set; }
        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
