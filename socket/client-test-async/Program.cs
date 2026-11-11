using System.Diagnostics;
using System.Net.Sockets;

const int N = 50;

const int Port = 12345;

Stopwatch sw = Stopwatch.StartNew();
List<Task> tasks = new List<Task>();
for (int i = 0; i < N; i++) {
    tasks.Add(CallServerAsync());
}

await Task.WhenAll(tasks);

sw.Stop();
Console.WriteLine("Elapsed time: " + sw.Elapsed);

async Task CallServerAsync()
{
    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    await client.ConnectAsync("127.0.0.1", Port);
    NetworkStream ns = new NetworkStream(client);
    StreamReader reader = new StreamReader(ns);
    string? response = await reader.ReadLineAsync();
    Console.WriteLine("Server response: " + response);
    reader.Close();
    ns.Close();
    client.Close();
}