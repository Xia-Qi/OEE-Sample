using Acme.Core.EquipmentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement.WebService
{
    public interface IEquipmentManagement
    {
        IList<Equipment> GetEquipments();
        IList<Procedure> GetProcedures();
        IList<Procedure> GetProcedures(DateTimeOffset t);
    }
}
