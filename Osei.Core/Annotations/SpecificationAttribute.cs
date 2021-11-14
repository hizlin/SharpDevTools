using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osei.Core.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class SpecificationAttribute : Attribute
    {
        public string? Since { get; set; }

        public string? Obsolete { get; set; }

    }
}
