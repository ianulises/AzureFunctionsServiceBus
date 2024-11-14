using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsServiceBus
{
    public class Sb
    {
        private readonly ILogger<Sb> _logger;

        public Sb(ILogger<Sb> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Sb))]
        public void Run([ServiceBusTrigger("myqueue", Connection = "")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
