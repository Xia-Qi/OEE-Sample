using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Acme.Core.Basic.Dal.Ef
{
    public abstract class BaseDbContext:DbContext
    {
        //"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=SSPI;";//
        private static string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        public BaseDbContext():base(_connectionString)
        {
            //var res = Database.CreateIfNotExists();
            //var res3 = Database.Exists();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<BaseObject>().Property(s=>s)
        }
    }
}
