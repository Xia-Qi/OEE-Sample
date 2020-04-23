using Acme.Core.Basic.Dal.Ef;
using Acme.Core.Basic.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Basic.Dal
{
    public class TextContext:BaseDbContext
    {
        public DbSet<Test> Tests { get; set; }
    }
}
