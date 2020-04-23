using Acme.Core.Basic.Dal.Ef;
using Acme.Core.EquipmentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement.Dal
{
    internal class EquipmentManagementContext : BaseDbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procedure>().Property(s => s.TheoreticallyMeter).HasPrecision(18, 6);
            modelBuilder.Entity<Procedure>().Property(s => s.RateOfTimeMovement).HasPrecision(18, 6);
            modelBuilder.Entity<Procedure>().Property(s => s.PerformanceYield).HasPrecision(18, 6);
            modelBuilder.Entity<Procedure>().Property(s => s.GlobalPlantEfficiency).HasPrecision(18, 6);

            base.OnModelCreating(modelBuilder);
        }
    }
}
