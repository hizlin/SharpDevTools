namespace VsTidy.Core.Models
{
    public class ProgramId : JsonBase
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public bool alwaysShowExtension { get; set; }
        public string path { get; set; }
        public string defaultIconPath { get; set; }
        public int defaultIconPosition { get; set; }
        public string arguments { get; set; }
        public bool dde { get; set; }
        public string ddeApplication { get; set; }
        public string ddeTopic { get; set; }
        public string iconHandler { get; set; }
        public string appUserModelId { get; set; }
        public string clsid { get; set; }
    }

}
