using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hpm.Previews.JetBrains
{
    public class JetBrainsProductService
    {
        HttpClient _Client;
        public JetBrainsProductService(HttpClient client)
        {
            this._Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codes">
        /// <para>IIU: IntelliJ IDEA Ultimate</para>
        /// <para>IIC: IntelliJ IDEA Community</para>
        /// <para>PCP: PyCharm Professional</para>
        /// <para>PCC: PyCharm Community</para>
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IEnumerable<Product>> GetProducts(params string[] codes)
        {
            if (codes == null || codes.Length == 0)
            {
                throw new ArgumentException(null, nameof(codes));
            }

            /* 接口来自:
             * https://www.jetbrains.com/idea/download/other.html
             * https://www.jetbrains.com/pycharm/download/other.html
             * https://www.jetbrains.com/go/download/other.html
             * https://www.jetbrains.com/datagrip/download/other.html
             * https://www.jetbrains.com/rider/download/other.html
             * 
             * 示例:
             * https://data.services.jetbrains.com/products?code=IIU%2CIIC&release.type=release&_=1637973226907
             */

            var code = Uri.EscapeDataString(string.Join(",", codes));
            var t = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var url = $@"https://data.services.jetbrains.com/products?code={code}&release.type=release&_={t}";

#if DEBUG
            var json = await _Client.GetStringAsync(url);
#endif
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
        public ProductType[] Types { get; set; }
        public string[] Categories { get; set; }
        public Release[] Releases { get; set; }
        public IDictionary<string, Distribution> Distributions { get; set; }
        public bool? ForSale { get; set; }
    }

    [DebuggerDisplay("{Id}: {Name}")]
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [DebuggerDisplay("{Id}: {Name}")]
    public class ProductType
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
