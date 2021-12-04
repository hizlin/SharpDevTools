using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace Hpm.Previews.MavenSupport
{
    class Test
    {
        string repo1 = @"https://repo1.maven.org/maven2/";
        string ttt = @"archetype-catalog.xml";

        string t2 = @"maven-metadata.xml";


        // private readonly IHttpClientFactory _HttpClientFactory;
        // public Test(IHttpClientFactory factory)
        // {
        //     this._HttpClientFactory = factory;
        // }


        public async Task TestUpdates()
        {
            var client = GetClient();

        }




        public async Task TestAliyun()
        {
            var client = GetClient();

            var url = @"https://maven.aliyun.com/repository/central/com/squareup/okhttp3/okhttp/3.14.9/okhttp-3.14.9.jar";

            var stream = await client.GetStreamAsync(url);

            using (var file = File.Create("okhttp-3.14.9.jar"))
            {
                await stream.CopyToAsync(file);
            }
        }

        public async Task Test3(string groupId, string artifactId)
        {
            var client = GetClient();

            var url = make(groupId, artifactId);
            url += t2;

            var text = await client.GetStringAsync(url);

            var root = XElement.Parse(text);
            var versions = root.Element("versioning")?.Element("versions")?.Elements("version").Select(x => x.Value).ToArray();


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

        public void Test2()
        {
            var path = "files/archetype-catalog.xml";

            var root = XElement.Load(path);

            var archetypes = root.Element("archetypes").Elements("archetype");

            var list = archetypes.Select(x => new Archetype()
            {
                GroupId = (string)x.Element("groupId"),
                ArtifactId = (string)x.Element("artifactId"),
                Version = (string)x.Element("version"),
                Description = (string)x.Element("description")
            }).ToArray();

            var list2 = list.Where(i => i.GroupId == "com.archetype").ToArray();
        }

        HttpClient GetClient()
        {
            var client = new HttpClient(); // _HttpClientFactory.CreateClient();
            var headers = client.DefaultRequestHeaders;
            headers.Add("User-Agent", "http-client");
            return client;
        }

        public async Task Test1()
        {
            var client = GetClient();


            var text = await client.GetStringAsync(repo1);


            // var html = new HtmlDocument();
            // html.LoadHtml(text);
            // 
            // var items = html.DocumentNode.SelectNodes("//a");
            // 
            // // var items = html.Element("body").Element("hr").Element("main").Element("pre").Elements("a");
            // // var catalog = items.Where(a => ttt.Equals(a.Value, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            // 
            // var catalog = items.Where(x => ttt.Equals(x.InnerText, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            // 
            // if (catalog != null)
            // {
            //     var builder = new UriBuilder(repo1);
            //     builder.Path = catalog.GetAttributeValue("href", string.Empty);
            //     var url = builder.ToString();
            // 
            //     var xml = await client.GetStringAsync(url);
            // }
        }
    }
}
