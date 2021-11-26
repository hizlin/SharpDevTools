// See https://aka.ms/new-console-template for more information
using AngleSharp;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using AngleSharp.Js;
using AngleSharp.Dom;
using AngleSharp.Io;
using System.Text;

try
{
    Test2();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();



static async void Test1()
{
    var client = new HttpClient();
    var text = await client.GetStringAsync("https://www.jetbrains.com/idea/download/other.html");
    var html = new HtmlDocument();
    html.LoadHtml(text);

    // html.DocumentNode.Elements("div")
}


static async void Test2()
{
    
    // var client = new HttpClient();
    // var text = await client.GetStringAsync("https://www.jetbrains.com/idea/download/other.html");
    // var parser = new HtmlParser();
    // var html = parser.ParseDocument(text);

    var console = new MyConsoleLogger();

    var configuration = Configuration.Default
                .WithJs()
                .WithEventLoop()
                .WithCss()
                .WithRenderDevice()
                .WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true })
                //.WithConsoleLogger(c => new MyConsoleLogger())
                ;

    var context = BrowsingContext.New(configuration);

    var html = await context.OpenAsync("https://www.jetbrains.com/idea/download/other.html");
    await html.WaitForReadyAsync();

    // //*[@id="previous-releases-react-root"]/section/div/div
    // #previous-releases-react-root > section > div > div
    // #previous-releases-react-root > section > div



    // //*[@id="previous-releases-react-root"]/section/div/div
    // #previous-releases-react-root > section > div > div
    // #previous-releases-react-root > section > div > div
    // #previous-releases-react-root > section > div > div
    // #previous-releases-react-root > section > div > div > div:nth-child(1)
    // #previous-releases-react-root > section > div > div > div:nth-child(2)
    var div = html.QuerySelector("#previous-releases-react-root > section > div > div");

    var count = html.ExecuteScript("document.querySelectorAll('#previous-releases-react-root > section > div > div').length");
}


class MyConsoleLogger : IConsoleLogger
{
    public void Log(object[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
        {
            sb.AppendLine((value ?? "null").ToString());
        }
        Console.WriteLine(sb.ToString());
    }
}