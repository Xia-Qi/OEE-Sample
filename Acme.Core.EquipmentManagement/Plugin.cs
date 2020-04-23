using Acme.Core.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.EquipmentManagement
{
    public class Plugin : IPlugin
    {
        public static string GetName()
        {
            return "Equipment";
        }
    }
}
