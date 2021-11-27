using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class JbProductService
    {
        HttpClient _Client = null;
        public JbProductService(HttpClient client)
        {
            this._Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /* IIU: IntelliJ IDEA Ultimate
         * IIC: IntelliJ IDEA Community
         * PCP: PyCharm Professional
         * PCC: PyCharm Community
         */
        public async Task<IEnumerable<Product>> GetProducts(params string[] codes)
        {
            if (codes == null || codes.Length == 0)
            {
                throw new ArgumentException(null, nameof(codes));
            }

            /* 示例:
             * https://data.services.jetbrains.com/products?code=IIU%2CIIC&release.type=release&_=1637973226907
             * https://data.services.jetbrains.com/products?code=PCP%2CPCC&release.type=release&_=1637973006924
             */

            var code = Uri.EscapeDataString(string.Join(",", codes));
            var url = $@"https://data.services.jetbrains.com/products?code={code}&release.type=release&_={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";

            using var stream = await _Client.GetStreamAsync(url);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var products = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(stream, options);
            return products ?? Enumerable.Empty<Product>();
        }
    }

    [DebuggerDisplay("{Name}")]
    public class Product
    {
        public string Code { get; set; }
        public string IntellijProductCode { get; set; }
        public string[] AlternativeCodes { get; set; }
        public string SalesCode { get; set; }
        public string Name { get; set; }
        public string ProductFamilyName { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Tag[] Tags { get; set; }
        public Type[] Types { get; set; }
        public string[] Categories { get; set; }
        public Release[] Releases { get; set; }
        public IDictionary<string, Distribution> Distributions { get; set; }
        public bool ForSale { get; set; }
    }

    [DebuggerDisplay("{Id}: {Name}")]
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [DebuggerDisplay("{Id}: {Name}")]
    public class Type
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class Distribution
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }

    [DebuggerDisplay("{Version}")]
    public class Release
    {
        public string Date { get; set; }
        public string Type { get; set; }
        public IDictionary<string, Download> Downloads { get; set; }
        public IDictionary<string, Patche[]> Patches { get; set; }
        public string NotesLink { get; set; }
        public bool LicenseRequired { get; set; }
        public string Version { get; set; }
        public string MajorVersion { get; set; }
        public string Build { get; set; }
        public string Whatsnew { get; set; }
        public IDictionary<string, string> UninstallFeedbackLinks { get; set; }
        public object PrintableReleaseType { get; set; }
    }

    public class Download
    {
        public string Link { get; set; }
        public long Size { get; set; }
        public string ChecksumLink { get; set; }
    }

    public class Patche
    {
        public string FromBuild { get; set; }
        public string Link { get; set; }
        public long Size { get; set; }
        public string ChecksumLink { get; set; }
    }
}
