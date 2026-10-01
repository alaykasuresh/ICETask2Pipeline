// References: Microsoft (2025) Azure Queue storage output bindings for Azure Functions

using System.Text.Json;
using ICETask2Pipeline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ICETask2Pipeline
{
    public class HttpToQueue
    {
        private readonly ILogger<HttpToQueue> _logger;

        public HttpToQueue(ILogger<HttpToQueue> logger)
        {
            _logger = logger;
        }

        [Function("HttpToQueue")]
        public async Task<HttpToQueueOutput> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();

            IncomingMessage? data;
            try
            {
                data = JsonSerializer.Deserialize<IncomingMessage>(body,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException)
            {
                data = null;
            }

            // Validate before anything goes onto the queue
            if (data == null || string.IsNullOrWhiteSpace(data.Name) || string.IsNullOrWhiteSpace(data.Message))
            {
                _logger.LogWarning("Invalid request body received.");
                return new HttpToQueueOutput
                {
                    QueueMessage = null,
                    HttpResponse = new BadRequestObjectResult("Please send JSON with at least a name and a message.")
                };
            }

            _logger.LogInformation("Message from {Name} is being added to the queue.", data.Name);

            return new HttpToQueueOutput
            {
                QueueMessage = JsonSerializer.Serialize(data),
                HttpResponse = new OkObjectResult($"Thanks {data.Name}, your message has been added to the queue.")
            };
        }
    }

    // Lets one function return an HTTP response AND write to a queue
    public class HttpToQueueOutput
    {
        [QueueOutput("messages-queue", Connection = "AzureWebJobsStorage")]
        public string? QueueMessage { get; set; }

        [HttpResult]
        public IActionResult HttpResponse { get; set; } = default!;
    }
}