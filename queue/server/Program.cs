using Azure.Identity;
using Azure.Storage.Queues;

Uri queuename = new Uri("https://thuifistvsys.queue.core.windows.net/demo");
var credential = new AzureCliCredential();
var client = new QueueClient(queuename, credential);
var message = client.ReceiveMessage();

if (message != null) {
    Console.WriteLine(message.Value?.MessageText);
    client.DeleteMessage(message.Value?.MessageId, message.Value?.PopReceipt);
}