//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VsTidy.Core
//{
//    [DebuggerDisplay("{type}: {id},version={version}")]
//    public partial class Package
//    {
//        public string id { get; set; }
//        public string version { get; set; }
//        public string type { get; set; }
//        public string chip { get; set; }
//        public string language { get; set; }

//        [DataMember(Name = "_vsInfo", EmitDefaultValue = false)]
//        public VisualStudioInformation VisualStudioInformation { get; set; }

//        public string license { get; set; }

//        public IDictionary<string, Dependency> dependencies { get; set; }
//        public ProjectClassifier[] projectClassifiers { get; set; }
//        public BreadcrumbTemplate breadcrumbTemplate { get; set; }

//        public Requirements requirements { get; set; }
//        public LocalizedResource[] localizedResources { get; set; }

//        // [DataMember(Name = "_buildInfo", EmitDefaultValue = false)]
//        // public ItemBuildInformation BuildInformation { get; set; }

//        public string GetFolderName()
//        {
//            // get
//            {
//                var builder = new StringBuilder();
//                builder.Append(this.id);
//                builder.AppendFormat(",version={0}", this.version);
//                if (!string.IsNullOrEmpty(this.chip))
//                    builder.AppendFormat(",chip={0}", this.chip);
//                if (!string.IsNullOrEmpty(this.language))
//                    builder.AppendFormat(",language={0}", this.language);
//                return builder.ToString();
//            }
//        }
//    }

//    [DataContract]
//    public abstract class InstallablePackage : Package
//    {
//        public string providerKey { get; set; }
//        public PropertyInitializer[] propertyInitializers { get; set; }
//        public Payload[] payloads { get; set; }

//        public InstallSizes installSizes { get; set; }

//        public FileAssociation[] fileAssociations { get; set; }

//        public UrlAssociation[] urlAssociations { get; set; }

//        public ProgId[] progIds { get; set; }
//        public DefaultProgram defaultProgram { get; set; }

//        public Shortcut[] shortcuts { get; set; }

//        public LogFile[] logFiles { get; set; }

//        [DataMember(Name = "permanent", EmitDefaultValue = false)]
//        public bool IsPermanent { get; set; }

//        public string[] relatedProcessDirectories { get; set; }
//        public string[] relatedProcessFiles { get; set; }
//        public string[] nonCriticalProcesses { get; set; }
//        public ConditionGroup detectConditions { get; set; }

//        public IEnumerable<string> GetFiles()
//        {
//            if (this.payloads != null && this.payloads.Length > 0)
//                foreach (var p in this.payloads)
//                {
//                    yield return p.fileName;
//                }
//        }
//    }

//    [DataContract]
//    public class ExePackage : InstallablePackage
//    {
//        [DataMember(IsRequired = true)]
//        public CommandParameter InstallParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter RepairParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter UninstallParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter LayoutParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter LayoutInstallParams { get; set; }

//        [DataMember]
//        public IDictionary<int, InstallResult> ReturnCodes { get; set; }
//    }
//    [DataContract]
//    public class MsiPackage : InstallablePackage
//    {
//        public IDictionary<string, string> MsiProperties { get; set; }
//        public string productCode { get; set; }
//        public string upgradeCode { get; set; }
//        public string productVersion { get; set; }
//        public int productLanguage { get; set; }
//        public bool visible { get; set; }

//    }

//    [DataContract]
//    public abstract class DismPackage : InstallablePackage
//    {
//    }
//    [DataContract]
//    public class MsuPackage : DismPackage
//    {
//    }
//    [DataContract]
//    public class WindowsFeature : DismPackage
//    {
//        [DataMember(EmitDefaultValue = false)]
//        public string Name { get; set; }
//    }

//    [DataContract]
//    public abstract class FilePackage<T> : InstallablePackage where T : FileItem
//    {
//        [DataMember(EmitDefaultValue = false)]
//        public IList<T> Files { get; set; }
//    }

//    [DataContract]
//    public class ZipPackage : FilePackage<FileItem>
//    {
//        [DataMember(EmitDefaultValue = false)]
//        public string RelativePath { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public IList<string> ExclusionPatterns { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public IList<string> Directories { get; set; }
//    }
//    [DataContract]
//    public class FileItem
//    {
//        [DataMember(IsRequired = true)]
//        public string FileName { get; set; }

//        [DataMember(IsRequired = true)]
//        public string Sha256 { get; set; }
//    }

//    [DataContract]
//    public class VsixPackage : FilePackage<VsixFile>
//    {
//        [DataMember(EmitDefaultValue = false)]
//        public string VsixId { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string DefaultNgenApplication { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string ExtensionDir { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public IDictionary<string, string> FolderMappings { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public IList<WebShortcut> WebShortcuts { get; set; }
//    }
//    [DataContract]
//    public class VsixFile : FileItem
//    {
//        [DataMember(EmitDefaultValue = false)]
//        public bool Ngen { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string NgenArchitecture { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string NgenApplication { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public int NgenPriority { get; set; }
//    }

//    public class Group : Package
//    {
//    }

//    [DataContract]
//    public abstract class SelectableGroup : Group
//    {

//    }

//    [DataContract]
//    public class Product : Group
//    {
//        [DataMember(IsRequired = false)]
//        public CommandParameter InstallParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter RepairParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter UninstallParams { get; set; }

//        [DataMember(EmitDefaultValue = false, Name = "initInstallParams")]
//        public CommandParameter InitializerInstallParams { get; set; }

//        [DataMember(EmitDefaultValue = false, Name = "initRepairParams")]
//        public CommandParameter InitializerRepairParams { get; set; }

//        [DataMember(EmitDefaultValue = false, Name = "initUninstallParams")]
//        public CommandParameter InitializerUninstallParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public CommandParameter LaunchParams { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string DefaultNgenApplication { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public Icon Icon { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string IconPath { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public string DefaultInstallDirectory { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public Uri ReleaseNotes { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public Uri ThirdPartyNotices { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public bool RecommendSelection { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public bool SupportsDownloadThenInstall { get; set; }
//    }

//    [DataContract]
//    public class Workload : Group
//    {
//        [DataMember(EmitDefaultValue = false)]
//        public Icon Icon { get; set; }
//    }

//    public class Component : Group
//    {
//        [DataMember(Name = "extension", EmitDefaultValue = false)]
//        public bool IsExtension { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public bool IsUiGroup { get; set; }

//        [DataMember(EmitDefaultValue = false)]
//        public UIProperties UI { get; set; }
//    }
//}
