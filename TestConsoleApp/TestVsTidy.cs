using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VsTidy.Core.Models;

namespace TestConsoleApp
{
    internal class TestVsTidy
    {
        public void Test()
        {
            var path = @"G:\Vs2022Offline\Catalog.json";

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var catalog = JsonSerializer.Deserialize<Catalog>(File.ReadAllText(path), options);
            var packages = catalog.packages;

            var types = packages.Select(p => p.type).Distinct().ToArray(); // 共计 11 种

            var products = packages.Where(p => p.type == "Product").ToArray();
            var workloads = packages.Where(p => p.type == "Workload").ToArray();
            var components = packages.Where(p => p.type == "Component").ToArray();
            var groups = packages.Where(p => p.type == "Group").ToArray();

            var files1 = packages.Where(p => p.type == "Vsix").ToArray();
            var files2 = packages.Where(p => p.type == "Zip").ToArray();
            var files3 = packages.Where(p => p.type == "Exe").ToArray();
            var files4 = packages.Where(p => p.type == "Msi").ToArray();
            var files5 = packages.Where(p => p.type == "Msu").ToArray();
            var files6 = packages.Where(p => p.type == "WindowsFeature").ToArray();
            var files7 = packages.Where(p => p.type == "Nupkg").ToArray();
        }

        public void RemoveOlds2022()
        {
            RemoveOlds(@"G:\Vs2022Offline", @"G:\Vs2022Offline-Olds");
        }

        void RemoveOlds(string source, string backup)
        {
            var path = Path.Combine(source, @"Catalog.json");
            if (!File.Exists(path))
                throw new FileNotFoundException("Catalog.json");

            if (!Directory.Exists(backup))
                Directory.CreateDirectory(backup);

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            var catalog = JsonSerializer.Deserialize<Catalog>(File.ReadAllText(path), options);

            var packages = catalog.packages;

            // 新的 全部安装文件
            var news = packages.Select(p => p.GetFolderName()).ToArray();

            var vss = packages.Where(c => c.id.StartsWith("Microsoft.VisualStudio.Branding.")).ToArray();

            // 不区分大小写
            var olds = new HashSet<string>(Directory.GetDirectories(source).Select(f => new DirectoryInfo(f).Name), StringComparer.OrdinalIgnoreCase);

            // 缺失
            var misses = packages.Where(p => p.language == "zh-CN").Select(p => p.GetFolderName()).Except(olds).ToArray();

            olds.ExceptWith(news); // 排除新的 剩下旧的
            olds.Remove("certificates"); // 排除 额外证书目录;
            // olds.Remove("Archive"); // 安装程序存档?

            // 下载器不会主动删除旧版本...
            foreach (var i in olds)
            {
                var old = Path.Combine(source, i);

                var bck = Path.Combine(backup, i);
                if (Directory.Exists(bck))
                    Directory.Delete(bck, true);

                Directory.Move(old, bck);
            }
        }
    }
}
