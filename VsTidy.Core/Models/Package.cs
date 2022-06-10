using System.Diagnostics;
using System.Text;

namespace VsTidy.Core.Models
{
    [DebuggerDisplay("{type}: {id},version={version}")]
    public class Package : JsonBase
    {
        public string id { get; set; }
        public string version { get; set; }
        public string type { get; set; }
        public Payload[] payloads { get; set; }
        public CommandParameter installParams { get; set; }
        public CommandParameter repairParams { get; set; }
        public CommandParameter uninstallParams { get; set; }
        public string providerKey { get; set; }
        public InstallSizes installSizes { get; set; }
        public string chip { get; set; }
        public string relativePath { get; set; }
        public ConditionGroup detectConditions { get; set; }
        public string productArch { get; set; }
        public string vsixId { get; set; }
        public string extensionDir { get; set; }
        public Requirements requirements { get; set; }
        public bool isUiGroup { get; set; }
        public string license { get; set; }
        public IDictionary<string, Dependency> dependencies { get; set; }
        public LocalizedResource[] localizedResources { get; set; }
        public bool extension { get; set; }
        public string productCode { get; set; }
        public string upgradeCode { get; set; }
        public string productVersion { get; set; }
        public int productLanguage { get; set; }
        public string[] relatedProcessDirectories { get; set; }
        public IDictionary<string, string> msiProperties { get; set; }
        public LogFile[] logFiles { get; set; }
        public bool outOfSupport { get; set; }
        public string machineArch { get; set; }
        public bool visible { get; set; }
        public IDictionary<string, string> folderMappings { get; set; }
        public string language { get; set; }
        public string[] relatedProcessFiles { get; set; }
        public string[] nonCriticalProcesses { get; set; }
        public string[] relatedServices { get; set; }
        public IDictionary<int, InstallResult> returnCodes { get; set; }
        public FileAssociation[] fileAssociations { get; set; }
        public ProgramId[] progIds { get; set; }
        public string name { get; set; }
        public IDictionary<string, object> _vsInfo { get; set; }
        public Shortcut[] shortcuts { get; set; }
        public DefaultProgram defaultProgram { get; set; }
        public IDictionary<string, object> ui { get; set; }
        public ProjectClassifier[] projectClassifiers { get; set; }
        public UrlAssociation[] urlAssociations { get; set; }
        public bool permanent { get; set; }
        public CommandParameter launchParams { get; set; }
        public Icon icon { get; set; }
        public string iconPath { get; set; }
        public string defaultInstallDirectory { get; set; }
        public string releaseNotes { get; set; }
        public string thirdPartyNotices { get; set; }
        public bool supportsExtensions { get; set; }
        public CommandParameter initInstallParams { get; set; }
        public CommandParameter initRepairParams { get; set; }
        public CommandParameter initUninstallParams { get; set; }
        public bool recommendSelection { get; set; }
        public bool supportsDownloadThenInstall { get; set; }
        public bool supportsDownloadThenUpdate { get; set; }
        public BreadcrumbTemplate breadcrumbTemplate { get; set; }
        public string nuGetPackageId { get; set; }
        public string nuGetPackageVersion { get; set; }
        public PropertyInitializer[] propertyInitializers { get; set; }

        public string GetFolderName()
        {
            var builder = new StringBuilder();
            builder.Append(this.id);
            builder.AppendFormat(",version={0}", this.version);
            if (!string.IsNullOrEmpty(this.chip))
                builder.AppendFormat(",chip={0}", this.chip);
            if (!string.IsNullOrEmpty(this.language))
                builder.AppendFormat(",language={0}", this.language);
            if (!string.IsNullOrEmpty(this.productArch))
                builder.AppendFormat(",productarch={0}", this.productArch);
            if (!string.IsNullOrEmpty(this.machineArch))
                builder.AppendFormat(",machinearch={0}", this.machineArch);
            return builder.ToString();
        }
    }
}
