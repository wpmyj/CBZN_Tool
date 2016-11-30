using System;
using System.Collections.Generic;
using System.Text;

namespace DB_ROM
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsAutoId : Attribute
    {
        public bool SetIsAutoId { get; set; }
    }
}
