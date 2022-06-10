using System.Text;
using System.Text.Json;
using TestConsoleApp;

try
{
    new TestVsTidy().RemoveOlds2022();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
