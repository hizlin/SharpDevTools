namespace VsTidy.Core.Models
{
    public class ConditionGroup : JsonBase
    {
        public string expression { get; set; }
        public ConditionBase[] conditions { get; set; }
    }

    public class ConditionBase // : JsonBase
    {
        public string id { get; set; }
    }

    public class Condition1 : ConditionBase
    {
        public string chip { get; set; }

        public string registryKey { get; set; }
        public string registryValue { get; set; }
        public string registryType { get; set; }
        public string registryData { get; set; }
    }

    public class Condition2
    {
        public string id { get; set; }

        public string filePath { get; set; }
        public string fileVersionRange { get; set; }

        public string productCode { get; set; }

        public string join { get; set; }

        public string registryKey { get; set; }
        public string registryValue { get; set; }
        public string registryData { get; set; }
        public string registryType { get; set; }
    }
}
