namespace VsTidy.Core.Models
{
    public class DefaultProgram : JsonBase
    {
        public string id { get; set; }
        public string registrationPath { get; set; }
        public string name { get; set; }
        public string descriptionPath { get; set; }
        public int descriptionPosition { get; set; }
    }

}
