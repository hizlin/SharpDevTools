using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hpm.Previews.NpmSupport
{
    public class JsonObjectBase : IJsonOnDeserialized
    {
        [JsonExtensionData]
        public IDictionary<string, object> ExtensionData { get; set; }

        public void OnDeserialized()
        {
#if DEBUG
            // if (this.ExtensionData != null && this.ExtensionData.Count > 0)
            // {
            //     throw new InvalidDataException("Has missing property.");
            // }
#endif
        }
    }

    public class NpmPackage : JsonObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("dist-tags")]
        public IDictionary<string, string> DistTags { get; set; }

        public IDictionary<string, DateTimeOffset> time { get; set; }


        public IDictionary<string, NpmVersion> versions { get; set; }
        public string readme { get; set; }
        public string homepage { get; set; }
        public string license { get; set; }


    }

    public class NpmVersion : JsonObjectBase
    {
        public string name { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string license { get; set; }
        public string[] keywords { get; set; }
        public string main { get; set; }
        public string module { get; set; }
        public string jsdelivr { get; set; }
        public string types { get; set; }
        public string homepage { get; set; }
        public NpmRepository repository { get; set; }

        public string[] sideEffects { get; set; }
        public IDictionary<string, string> scripts { get; set; }
        public IDictionary<string, string> dependencies { get; set; }
        public IDictionary<string, string> devDependencies { get; set; }

        public string gitHead { get; set; }
        public string _id { get; set; }
        public string _nodeVersion { get; set; }
        public string _npmVersion { get; set; }
        public NpmDist dist { get; set; }
        public bool _hasShrinkwrap { get; set; }
        public long publish_time { get; set; }
        public long _cnpm_publish_time { get; set; }
        public string readme { get; set; }
    }

    public class NpmDist
    {
        public string shasum { get; set; }
        public long size { get; set; }
        public bool noattachment { get; set; }
        public string tarball { get; set; }
    }

    public class NpmRepository
    {
        public string Type { get; set; }

        public string Url { get; set; }
    }

}