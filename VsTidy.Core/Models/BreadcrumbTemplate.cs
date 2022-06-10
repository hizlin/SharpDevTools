namespace VsTidy.Core.Models
{
    public class BreadcrumbTemplate : JsonBase
    {
        public Template[] templates { get; set; }
        public LocalizedResourceTemplate[] localizedResources { get; set; }
    }

    public class Template : JsonBase
    {
        public string id { get; set; }
        public int projectSortOrder { get; set; }
        public string projectType { get; set; }
        public string[] selects { get; set; }
        public string projectSubTypeSortOrder { get; set; }
        public string projectSubType { get; set; }
    }

    public class LocalizedResourceTemplate : JsonBase
    {
        public string language { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public string templateId { get; set; }
        public string projectTypeDisplayName { get; set; }
        public string projectSubTypeDisplayName { get; set; }
    }
}
