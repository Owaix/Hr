﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace DataAccess
{
    public class HRDbContext : DbContext
    {
        public HRDbContext() : base(ConfigurationManager.ConnectionStrings["HRMSCOnStr"].ConnectionString)
        {
          
        }
        public DbSet<Features> feature { get; set; }
        public DbSet<Roles> role { get; set; }
        public DbSet<FeatureAccessConfig> FRConfig { get; set; }

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
