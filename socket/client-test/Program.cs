using System.Diagnostics;
using System.Net.Sockets;

const int N = 50;

const int Port = 12345;

Stopwatch sw = Stopwatch.StartNew();
List<Thread> threads = new List<Thread>();
for (int i = 0; i < N; i++) {
    Thread t = new Thread( () => {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect("127.0.0.1", Port);
        NetworkStream ns = new NetworkStream(client);
        StreamReader reader = new StreamReader(ns);
        string? response = reader.ReadLine();
        Console.WriteLine("Server response: " + response);
        reader.Close();
        ns.Close();
        client.Close();
    });
    threads.Add(t);
    t.Start();
}

threads.ForEach(t => t.Join());

sw.Stop();
Console.WriteLine("Elapsed time: " + sw.Elapsed);
