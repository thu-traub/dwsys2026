using System.Net.Sockets;

const int Port = 12345;
Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
server.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
server.Listen(10);
Console.WriteLine("Server is listening on port " + Port);
while (true) {
    Socket client = server.Accept();
    //Console.WriteLine("Client connected.");
    _ = HandleClientAsync(client);
}

async Task HandleClientAsync(Socket client) {
    NetworkStream ns = new NetworkStream(client);
    StreamWriter writer = new StreamWriter(ns);
    await Task.Delay(1000);
    await writer.WriteLineAsync(DateTime.Now.ToString());
    await writer.FlushAsync();
    ns.Close();
    client.Close();
}

// server.Close();