using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsTidy.Core.Models
{
    public class Catalog : JsonBase
    {
        public string manifestVersion { get; set; }
        public string engineVersion { get; set; }
        public Info info { get; set; }
        public Signer[] signers { get; set; }
        public Package[] packages { get; set; }
        public IDictionary<string, object> deprecate { get; set; }
        public Signature signature { get; set; }
    }
}
