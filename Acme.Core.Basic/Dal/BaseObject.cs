using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Core.Basic.Dal
{
    public abstract class BaseObject:IBaseObject
    {
        public virtual long Id { get; set; }
        public virtual long Version { get; set; }
        public virtual DateTimeOffset CreateDateTime { get; set; }
        public virtual DateTimeOffset ModifyDateTime { get; set; }
    }
}
