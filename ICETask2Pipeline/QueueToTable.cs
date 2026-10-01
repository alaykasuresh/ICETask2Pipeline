// References: Microsoft (2025) Azure Queue storage trigger for Azure Functions; Microsoft (2025) Azure Tables output bindings for Azure Functions

using ICETask2Pipeline.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ICETask2Pipeline
{
    public class QueueToTable
    {
        private readonly ILogger<QueueToTable> _logger;

        public QueueToTable(ILogger<QueueToTable> logger)
        {
            _logger = logger;
        }

        [Function("QueueToTable")]
        [TableOutput("Messages", Connection = "AzureWebJobsStorage")]
        public MessageEntity Run(
            [QueueTrigger("messages-queue", Connection = "AzureWebJobsStorage")] IncomingMessage queueMessage)
        {
            _logger.LogInformation("Queue message received from {Name}. Writing to Table Storage.", queueMessage.Name);

            var entity = new MessageEntity
            {
                Name = queueMessage.Name,
                Email = queueMessage.Email,
                Message = queueMessage.Message
            };

            _logger.LogInformation("Saved entity with RowKey {RowKey} to the Messages table.", entity.RowKey);

            return entity;
        }
    }
}