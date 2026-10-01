// References: Microsoft (2025) Azure Tables output bindings for Azure Functions

using System;
using System.Collections.Generic;
using System.Text;

namespace ICETask2Pipeline.Models
{
    public class MessageEntity
    {
        // Every table row needs a PartitionKey and a RowKey
        public string PartitionKey { get; set; } = "Messages";
        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime ReceivedAtUtc { get; set; } = DateTime.UtcNow;
    }
}

