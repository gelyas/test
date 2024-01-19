using RestSharp;

namespace TestDocker_
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 1;
            while (i <= 3)
            //while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                string message = "ќтправл€ю это сообщение из докера";
                var options = new RestClientOptions("http://smmon")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/slatatelegram/?token=ef6ccc86-8d7f-4cbd-8019-2a8c1bc1c0f2&chatid=320505713&message=" + message, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);

                i++;
            }
        }
    }
}