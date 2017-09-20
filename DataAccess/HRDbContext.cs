using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HRDbContext : DbContext
    {
        public HRDbContext() : base(ConfigurationManager.ConnectionStrings["HRMSCOnStr"].ConnectionString)
        {
            Database.SetInitializer<HRDbContext>(null);
        }
        public DbSet<Employee> Employee { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
