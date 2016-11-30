using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DB_ROM
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PrimaryKey : Attribute
    {
        public string SetPrimaryKey { get; set; }
    }
}
