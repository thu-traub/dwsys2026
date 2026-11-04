using System.Net.Sockets;

const int Port = 12345;
Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
server.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
server.Listen(1);
Console.WriteLine("Server is listening on port " + Port);
while (true) {
    Socket client = server.Accept();
    Console.WriteLine("Client connected.");
    NetworkStream ns = new NetworkStream(client);
    StreamReader reader = new StreamReader(ns);
    string? line = reader.ReadLine();
    Console.WriteLine("Received: " + line);
    reader.Close();
    ns.Close();
    client.Close();
}
// server.Close();