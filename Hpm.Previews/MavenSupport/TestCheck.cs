using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hpm.Previews.MavenSupport
{
    class TestCheck
    {
        string repo1 = @"https://repo1.maven.org/maven2/";

        string t2 = @"maven-metadata.xml";
        // private readonly IHttpClientFactory _HttpClientFactory;
        // public TestCheck(IHttpClientFactory factory)
        // {
        //     this._HttpClientFactory = factory;
        // }

        HttpClient GetClient()
        {
            var client = new HttpClient(); // _HttpClientFactory.CreateClient();
            var headers = client.DefaultRequestHeaders;
            headers.Add("User-Agent", "http-client");
            return client;
        }

        public async Task Test3(string groupId, string artifactId, string range)
        {
            var client = GetClient();

            var url = make(groupId, artifactId);
            url += t2;

            var text = await client.GetStringAsync(url);

            var root = XElement.Parse(text);
            // var versions = root.Element("versioning")?.Element("versions")?.Elements("version").Select(x => x.Value).ToArray();


            var serializer = new XmlSerializer(typeof(MavenNet.Models.Metadata));
            var metadata = (MavenNet.Models.Metadata)serializer.Deserialize(new StringReader(text));

            var v = metadata.Versioning;
            DateTime.TryParseExact(v.LastUpdated, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out var time);

            // MavenNet.Models.Versioning

            var latest = v.Latest;
            if (!string.IsNullOrWhiteSpace(range))
            {
                var array = v.Versions.Select(i => MavenVersion.Parse(i)).ToArray();
            }

            var n = (DateTime.UtcNow - time).TotalDays <= 7.0 ? "New" : "";

            Console.WriteLine($"{artifactId}: {latest} / {time.ToString("s")} {n}");

            // NuGetVersion.TryParse(versions[0], out var v1);
            // SemanticVersion.TryParse(versions[0], out var v2);
            // 
            // var vs = versions.Select(i => SemanticVersion.TryParse(i, out var v) ? v : null).ToArray();
        }

        string make(string groupId, string artifactId)
        {
            //var builder = new UriBuilder(repo1);
            //builder.Path = groupId.Replace(".", "/");
            //return builder.ToString();
            return $"{repo1}{groupId.Replace(".", "/")}/{artifactId}/";
        }
    }
}
