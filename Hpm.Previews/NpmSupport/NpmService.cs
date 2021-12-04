using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hpm.Previews.NpmSupport
{
    public class NpmService
    {
        readonly HttpClient _Client;

        public NpmService(HttpClient client)
        {
            _Client = client;
        }

        public async Task Test()
        {
            // var @base = @"https://registry.npmjs.org";
            var @base = @"https://registry.npm.taobao.org";

            var client = new HttpClient();
            client.BaseAddress = new Uri(@base);

            var json = await client.GetStringAsync("@vue/cli");

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var package = JsonSerializer.Deserialize<NpmPackage>(json, options);

            package.DistTags.TryGetValue("latest", out var latest);

            package.time.TryGetValue(latest, out var time);

            package.time.TryGetValue("modified", out var modified);

            Console.WriteLine($"{package.Name} {latest} {time.ToString("u")}");
        }
    }
}
