// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;
using TestConsoleApp;

try
{
    Test1().Wait();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();


static async Task Test1()
{
    var client = new HttpClient();
    var service = new JbProductService(client);
    var products = await service.GetProducts("IIU", "IIC");
    var iiu = products?.Where(p => p.Code == "IIU").SingleOrDefault()?.Releases?.FirstOrDefault();

    Console.WriteLine($"IDEA v{iiu?.Version} {iiu?.Date}");
}