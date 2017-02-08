using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestGAP.Models
{
    public class Context : DbContext 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}