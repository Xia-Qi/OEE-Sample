using Acme.Core.Basic.Dal.Ef;
using Acme.Core.EquipmentManagement.Dal;
using Acme.Core.EquipmentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement.Service
{
    internal class EquipmentManagement
    {
        private EquipmentManagementContext dbContext = null;
        public EquipmentManagement()
        {
            dbContext = new EquipmentManagementContext();
        }
        internal async void CreateEquipment(Equipment equipment)
        {
            if (dbContext.Equipments.Find(new { Name = equipment.Name }) != null)
            {
                return;
            }
            dbContext.Equipments.Add(equipment);

            await dbContext.SaveChangesAsync();
        }
        internal IList<Equipment> GetEquipments()
        {
            return dbContext.Equipments.ToList();
        }
        internal IList<Procedure> GetProcedures()
        {
            return dbContext.Procedures.ToList();
        }
        internal IList<Procedure> GetProcedures(DateTimeOffset t)
        {
            var nextDay = t.AddDays(1);;
            var start = new DateTimeOffset(t.Year, t.Month, t.Day, 0, 0, 0, TimeSpan.Zero);
            var to = new DateTimeOffset(nextDay.Year, nextDay.Month, nextDay.Day, 0, 0, 0, TimeSpan.Zero);

            var result = from p in dbContext.Procedures
                       where p.CreateDateTime >= start
                       && p.CreateDateTime < to
                       select p;

            return result.ToList();
        }
    }
}
