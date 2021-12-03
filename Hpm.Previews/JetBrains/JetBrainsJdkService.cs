using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hpm.Previews.JetBrains
{
    public class JetBrainsJdkService
    {
        readonly HttpClient _Client;

        public JetBrainsJdkService(HttpClient client)
        {
            this._Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Jdk>> LoadAsync()
        {
            // var url1 = @"https://download.jetbrains.com/jdk/feed/v1/jdks.json.xz";
            var url2 = @"https://download-cdn.jetbrains.com/jdk/feed/v1/jdks.json.xz";

            // var stream = await client.GetByteArrayAsync(url2);
            var stream = await _Client.GetStreamAsync(url2);

            // XZStream 不能直接读取 HttpClient.GetStreamAsync() 返回的流;
            var memory = new MemoryStream();
            await stream.CopyToAsync(memory);
            memory.Seek(0L, SeekOrigin.Begin);

            var xz = new XZStream(memory);
            var reader = new StreamReader(xz);
            var json = reader.ReadToEnd();

            // var options = new JsonSerializerOptions();
            var feed = JsonSerializer.Deserialize<JetBrainsJdkFeed>(json);
            return feed?.Jdks;
        }

    }
}
