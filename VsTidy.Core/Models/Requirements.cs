namespace VsTidy.Core.Models
{
    public class Requirements : JsonBase
    {
        public IDictionary<string, string> functors { get; set; }
        public string supportedOS { get; set; }
        public ConditionGroup conditions { get; set; }
    }

}
