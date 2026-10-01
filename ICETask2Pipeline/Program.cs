/*
- Name : Alayka Suresh
- Student number:ST10440215
- ICE Task 2 - CLDV6212 
- PIPELINE ACTIVITY
- REFERENCES:
 Microsoft. 2025. Guide for running C# Azure Functions in the isolated worker model. [Online]. Available at: https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide [Accessed 1 October 2026].
 Microsoft. 2025. Azure Queue storage output bindings for Azure Functions. [Online]. Available at: https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue-output [Accessed 1 October 2026].
 Microsoft. 2025. Azure Queue storage trigger for Azure Functions. [Online]. Available at: https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue-trigger [Accessed 1 October 2026].
 Microsoft. 2025. Azure Tables output bindings for Azure Functions. [Online]. Available at: https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-table-output [Accessed 1 October 2026].
 */

using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")))
{
    builder.Services.AddOpenTelemetry()
        .UseFunctionsWorkerDefaults()
        .UseAzureMonitorExporter();
}

builder.Build().Run();
