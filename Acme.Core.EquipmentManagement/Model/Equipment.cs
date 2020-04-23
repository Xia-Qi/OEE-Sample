using Acme.Core.Basic.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement.Model
{
    [Table("Equipment", Schema ="EquipmentManagement")]
    public class Equipment : BaseObject
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        
        //其它，如：规格，型号，价值，损耗，归属，维保信息等
    }
}
