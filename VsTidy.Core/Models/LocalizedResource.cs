namespace VsTidy.Core.Models
{
    public class LocalizedResource : JsonBase
    {
        public string language { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public string category { get; set; }
        public string[] keywords { get; set; }
        public string license { get; set; }
        public string longDescription { get; set; }
    }

}
