//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VsTidy.Core
//{
//    class VsOffline
//    {
//        /* Visual Studio 2017 workload and component IDs
//         * https://docs.microsoft.com/en-us/visualstudio/install/workload-and-component-ids
//         * 
//         * Product:
//         * Visual Studio Enterprise 2017
//         * Visual Studio Professional 2017
//         * Visual Studio Community 2017
//         * Visual Studio Team Explorer 2017
//         * Visual Studio Desktop Express 2017
//         * Visual Studio Build Tools 2017
//         * Visual Studio Test Agent 2017
//         * Visual Studio Test Controller 2017
//         * Visual Studio Test Professional 2017
//         * Visual Studio Feedback Client 2017
//         * 
//         * Workload: // 工作负载
//         * 
//         * Component: // 单个组件
//         */
//        public static JsonCatalog Catalog { get; set; }

//        HttpClient _Client;
//        string _UrlInstaller = @"https://aka.ms/vs/15/release/installer"; // vs_installer.opc
//        string _UrlChannel = @"https://aka.ms/vs/15/release/channel";

//        // ChannelManifest.json
//        public async Task<JsonChannelManifest> GetChannelManifestAsync()
//        {
//            if (_Client == null)
//            {
//                _Client = new HttpClient();
//            }

//            var response = await _Client.GetAsync(_UrlChannel);
//            if (!response.IsSuccessStatusCode)
//                throw new InvalidOperationException();

//            var link = response.RequestMessage.RequestUri; // 实际下载地址;
//            var json = await response.Content.ReadAsStringAsync();
//            var data = JsonConvert.DeserializeObject<JsonChannelManifest>(json);
//            return data;
//        }

//        // Catalog.json
//        public async Task<JsonCatalog> Test(JsonChannelManifest channel)
//        {
//            var manifest = channel.channelItems.Where(i => i.type == "Manifest").FirstOrDefault();

//            var payload = manifest.payloads.FirstOrDefault();

//            var response = await _Client.GetAsync(payload.url);
//            if (!response.IsSuccessStatusCode)
//                throw new InvalidOperationException();

//            var link = response.RequestMessage.RequestUri; // 实际下载地址;
//            var json = await response.Content.ReadAsStringAsync();

//            var settings = new JsonSerializerSettings()
//            {
//                MissingMemberHandling = MissingMemberHandling.Error, // 如果出现新的成员, 抛出异常;
//            };

//            var data = JsonConvert.DeserializeObject<JsonCatalog>(json, settings);
//            return data;
//        }
//    }
//}
