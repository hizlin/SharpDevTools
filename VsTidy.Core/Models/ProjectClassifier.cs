namespace VsTidy.Core.Models
{
    public class ProjectClassifier : JsonBase
    {
        public string id { get; set; }
        public string extension { get; set; }
        public string factoryGuid { get; set; }
        public int priority { get; set; }
        public MatcherData[] matcherData { get; set; }
        public string matcherId { get; set; }
        public string appliesTo { get; set; }
        public string[] selects { get; set; }
    }

    public class MatcherData : JsonBase
    {
        public string type { get; set; }
        public string capabilityType { get; set; }
        public string projectPropertyId { get; set; }
        public string regExMatchSource { get; set; }
    }
}
