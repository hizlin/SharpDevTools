// See https://aka.ms/new-console-template for more information
using Hpm.Previews.JetBrains;
using System.Text;
using System.Text.Json;

try
{
    Test2().Wait();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();


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
    var client=new HttpClient();
    var service = new JetBrainsJdkService(client);
    var jdks = await service.LoadAsync();

}