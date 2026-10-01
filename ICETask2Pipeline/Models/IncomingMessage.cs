// References: Microsoft (2025) Guide for running C# Azure Functions in the isolated worker model

using System;
using System.Collections.Generic;
using System.Text;

namespace ICETask2Pipeline.Models
{
    public class IncomingMessage
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
