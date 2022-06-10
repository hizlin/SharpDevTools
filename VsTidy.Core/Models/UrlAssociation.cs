namespace VsTidy.Core.Models
{
    public class UrlAssociation : JsonBase
    {
        public string protocol { get; set; }
        public string displayName { get; set; }
        public string progId { get; set; }
        public string defaultProgramRegistrationPath { get; set; }
    }

}
