using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hpm.Core
{
    /**
     * By: JetBrains
     * https://download.jetbrains.com/jdk/feed/v1/jdks.json.xz
     * https://download-cdn.jetbrains.com/jdk/feed/v1/jdks.json.xz
     */
    public class JdkFeed
    {
        [JsonPropertyName("jdks")]
        public Jdk[] Jdks { get; set; }

    }

    [DebuggerDisplay("{Vendor} {Product} {JdkVersion} {GetFirstPackagePlatform()}")]
    public class Jdk
    {
        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("jdk_version_major")]
        public int JdkVersionMajor { get; set; }

        [JsonPropertyName("jdk_version")]
        public string JdkVersion { get; set; }

        [JsonPropertyName("jdk_vendor_version")]
        public string JdkVendorVersion { get; set; }

        [JsonPropertyName("suggested_sdk_name")]
        public string SuggestedSdkName { get; set; }

        [JsonPropertyName("shared_index_aliases")]
        public string[] SharedIndexAliases { get; set; }

        [JsonPropertyName("packages")]
        public Package[] Packages { get; set; }

        [JsonPropertyName("default")]
        public bool? Default { get; set; }

        [JsonPropertyName("flavour")]
        public string Flavour { get; set; }

        [JsonPropertyName("listed")]
        public bool? Listed { get; set; }

        public string GetFirstPackagePlatform()
        {
            if (this.Packages != null && this.Packages.Length > 0)
            {
                var first = this.Packages[0];
                return $"{first.Os}-{first.Arch}";
            }
            return null;
        }
    }

    [DebuggerDisplay("{Os}-{Arch}")]
    public class Package
    {
        [JsonPropertyName("os")]
        public string Os { get; set; }

        [JsonPropertyName("arch")]
        public string Arch { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("package_type")]
        public string PackageType { get; set; }

        [JsonPropertyName("unpack_prefix_filter")]
        public string UnpackPrefixFilter { get; set; }

        [JsonPropertyName("package_root_prefix")]
        public string PackageRootPrefix { get; set; }

        [JsonPropertyName("package_to_java_home_prefix")]
        public string PackageToJavaHomePrefix { get; set; }

        [JsonPropertyName("archive_file_name")]
        public string ArchiveFileName { get; set; }

        [JsonPropertyName("install_folder_name")]
        public string InstallFolderName { get; set; }

        [JsonPropertyName("archive_size")]
        public int ArchiveSize { get; set; }

        [JsonPropertyName("unpacked_size")]
        public int UnpackedSize { get; set; }

        [JsonPropertyName("sha256")]
        public string Sha256 { get; set; }

        [JsonPropertyName("filter")]
        public Filter Filter { get; set; }
    }

    public class Filter
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("arch")]
        public string Arch { get; set; }
    }
}
