using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hpm.Core
{
    public static class JdkHelper
    {
        public async static Task<Jdk[]> LoadJdks()
        {
            var url1 = @"https://download.jetbrains.com/jdk/feed/v1/jdks.json.xz";
            var url2 = @"https://download-cdn.jetbrains.com/jdk/feed/v1/jdks.json.xz";

            var handler = new HttpClientHandler()
            {
                UseCookies = false,
            };
            var client = new HttpClient(handler);

            // var stream = await client.GetByteArrayAsync(url2);
            var stream = await client.GetStreamAsync(url2);
            var memory = new MemoryStream();
            await stream.CopyToAsync(memory);
            memory.Seek(0L, SeekOrigin.Begin);

            var xz = new XZStream(memory);
            var reader = new StreamReader(xz);
            var json = reader.ReadToEnd();

            // var options = new JsonSerializerOptions();
            var feed = System.Text.Json.JsonSerializer.Deserialize<JdkFeed>(json);
            return feed?.Jdks;
        }
    }
}
