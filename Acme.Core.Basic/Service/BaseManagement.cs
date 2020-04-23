using Acme.Core.Basic.Dal;
using Acme.Core.Basic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Core.Basic.Service
{
    public class BaseManagement
    {
        public IList<Test> GetTests()
        {
            var context = new TextContext();
            if(context.Tests.Count() == 0)
            {
                context.Tests.Add(new Test() { Name = "test1" });
                var res = context.SaveChanges();
            }
            return context.Tests.ToList();
        }
    }
}
