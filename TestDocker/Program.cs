//using RestSharp;

//string message = "Отправляю это сообщение из докера";
//var options = new RestClientOptions("http://smmon")
//{
//    MaxTimeout = -1,
//};
//var client = new RestClient(options);
//var request = new RestRequest("/slatatelegram/?token=ef6ccc86-8d7f-4cbd-8019-2a8c1bc1c0f2&chatid=320505713&message=" + message, Method.Get);
//RestResponse response = await client.ExecuteAsync(request);
//Console.WriteLine(response.Content);

using Microsoft.AspNetCore.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseUrls("http://*:5000") // listen on port 5000 on all network interfaces
            .UseStartup<Startup>()
            .Build();

        host.Run();
    }
}
