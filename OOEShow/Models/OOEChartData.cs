using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOEShow.Models
{
    [Serializable]
    public class OOEChartData
    {
        public string TypeName { get; set; }
        public decimal Value { get; set; }
        public string EquipmentName { get; set; }
    }
}