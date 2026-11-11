using Azure.Identity;
using Azure.Storage.Queues;

Uri queuename = new Uri("https://thuifistvsys.queue.core.windows.net/demo");
var credential = new AzureCliCredential();
var client = new QueueClient(queuename, credential);
client.SendMessage("Hello, World 2!");
