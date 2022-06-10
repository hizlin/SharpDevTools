namespace VsTidy.Core.Models
{
    public class Shortcut : JsonBase
    {
        public string description { get; set; }
        public string targetPath { get; set; }
        public string displayName { get; set; }
        public string folder { get; set; }
        public string workingDirectory { get; set; }
        public string arguments { get; set; }

        public IDictionary<string, string> shellProperties { get; set; }
    }

}
