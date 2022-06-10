namespace VsTidy.Core.Models
{
    public class PropertyInitializer : JsonBase
    {
        public string key { get; set; }
        public string value { get; set; }
        public string property { get; set; }
        public string defaultValue { get; set; }
    }

}
