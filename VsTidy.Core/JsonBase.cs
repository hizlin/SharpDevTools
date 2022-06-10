using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VsTidy.Core
{
    public class JsonBase
#if DEBUG
        : IJsonOnDeserialized
    {
        [JsonExtensionData]
        public IDictionary<string, object> MissingProperties { get; set; }

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (this.MissingProperties?.Count > 0)
            {
                throw new JsonException($"Contains missing properties: {string.Join(", ", MissingProperties.Keys)}.");
            }
        }
    }
#else
    {
    }
#endif
}
