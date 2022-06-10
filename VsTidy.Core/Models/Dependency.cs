using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VsTidy.Core.Models
{
    /* 两种格式:
     * 
     * "Microsoft.VisualStudio.Editors": "[15.0,16.0)"
     * 
     * "Microsoft.VisualStudio.PackageGroup.ProfessionalCore": {
     *     "version": "[15.0,16.0)",
     *     "when": ["Microsoft.VisualStudio.Product.Professional", "Microsoft.VisualStudio.Product.Enterprise"]
     *  },
     */
    [JsonConverter(typeof(DependencyConverter))]
    public class Dependency
    {
        public string Id { get; set; }
        public string version { get; set; }
        public string chip { get; set; }
        public string language { get; set; }
        public string type { get; set; }
        public string behaviors { get; set; }
        public string[] when { get; set; }

        public string machineArch { get; set; }
    }

    public class DependencyConverter : JsonConverter<Dependency>
    {
        public override Dependency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = new Dependency();

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                {
                    var name = reader.GetString();
                    switch (name)
                    {
                        case "id":
                            {
                                reader.Read();
                                result.Id = reader.GetString();
                            }
                            break;
                        case "version":
                            {
                                reader.Read();
                                result.version = reader.GetString();
                            }
                            break;
                        case "chip":
                            {
                                reader.Read();
                                var value = reader.GetString();
                                result.chip = value;
                            }
                            break;
                        case "behaviors":
                            {
                                reader.Read();
                                result.behaviors = reader.GetString();
                            }
                            break;
                        case "type":
                            {
                                reader.Read();
                                result.type = reader.GetString();
                            }
                            break;
                        case "language":
                            {
                                reader.Read();
                                result.language = reader.GetString();
                            }
                            break;
                        case "when":
                            {
                                reader.Read(); // StartArray

                                var array = new List<string>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    array.Add(reader.GetString());
                                }

                                result.when = array.ToArray();
                            }
                            break;
                        case "machineArch":
                            {
                                reader.Read();
                                result.machineArch = reader.GetString();
                            }
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }
            else
            {
                result.version = reader.GetString();
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, Dependency value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
