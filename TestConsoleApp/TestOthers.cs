using Hpm.Previews.JetBrains;
using Hpm.Previews.NpmSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    internal class TestOthers
    {
        static async Task Test1()
        {
            var client = new HttpClient();
            var service = new JetBrainsProductService(client);
            var products = await service.GetProducts(JetBrainsProducts.IdeaUltimate, JetBrainsProducts.PyCharmProfessional);

            foreach (var p in products)
            {
                var r = p.Releases?.FirstOrDefault();
                var link = r?.Downloads?.TryGetValue("windows", out var value) == true ? value.Link : null;

                Console.WriteLine($"{p.Name} v{r?.Version} {r?.Date} {link}");
            }
        }

        static async Task Test2()
        {
            var client = new HttpClient();
            var service = new JetBrainsJdkService(client);
            var jdks = await service.LoadAsync();

            var major = 17;
            var list = jdks.Where(k => k.JdkVersionMajor == major)
                .Where(k => string.Equals(k.Packages?[0].Os, "windows", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var count = list.Count;
        }

        static async Task Test3()
        {
            var client = new HttpClient();
            var service = new NpmService(client);
            await service.Test();
        }
    }
}
