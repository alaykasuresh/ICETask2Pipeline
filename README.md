# ICE Task 2: Azure Functions Pipeline

**Alayka Suresh** | ST10440215 | CLDV6212 Cloud Development B

## Overview

An Azure Functions pipeline (.NET 8 isolated) that sends data from Postman through a queue into Table Storage.

```
Postman --> HttpToQueue --> messages-queue --> QueueToTable --> Messages table
```

- **HttpToQueue:** HTTP triggered function that validates the request and writes it to the queue
- **QueueToTable:** queue triggered function that saves the message to Table Storage

## How to Run

1. Open the solution in Visual Studio and press **F5** (Azurite starts automatically).
2. In Postman, send a POST request to `http://localhost:7071/api/HttpToQueue` with:
   ```json
   { "name": "Alayka Suresh", "email": "alaykasuresh@gmail.com", "message": "Test message" }
   ```
3. Check **Azure Storage Explorer → Emulator → Tables → Messages** for the new entry.

## Video

https://youtu.be/CSg8OxZdFO0


## References

Microsoft. 2025. Azure Functions documentation. [Online]. Available at: https://learn.microsoft.com/en-us/azure/azure-functions/ [Accessed 1 October 2026].
