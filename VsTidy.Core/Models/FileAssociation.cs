namespace VsTidy.Core.Models
{
    public class FileAssociation : JsonBase
    {
        public string extension { get; set; }
        public string progId { get; set; }
        public string defaultProgramRegistrationPath { get; set; }
        public string perceivedType { get; set; }
        public string contentType { get; set; }
        public bool isIconOnly { get; set; }
    }

}
