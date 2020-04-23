using Acme.Core.Basic.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Core.Basic.Model
{
    [Table("Test",Schema = "Basic")]
    public class Test:BaseObject
    {
        public virtual string Name { get; set; }
    }
}
