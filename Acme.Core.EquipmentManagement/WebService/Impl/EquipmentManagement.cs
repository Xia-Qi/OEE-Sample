using Acme.Core.EquipmentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement.WebService.Impl
{
    public class EquipmentManagement : IEquipmentManagement
    {
        private static Service.EquipmentManagement equipmentManagement = null;
        public EquipmentManagement()
        {
            equipmentManagement = new Service.EquipmentManagement();
        }

        public IList<Equipment> GetEquipments() => equipmentManagement.GetEquipments();

        public IList<Procedure> GetProcedures() => equipmentManagement.GetProcedures();

        public IList<Procedure> GetProcedures(DateTimeOffset t) => equipmentManagement.GetProcedures(t);
    }
}
