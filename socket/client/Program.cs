using System.Net.Sockets;

const int Port = 12345;
Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
client.Connect("127.0.0.1", Port);
NetworkStream ns = new NetworkStream(client);
StreamWriter writer = new StreamWriter(ns);
writer.WriteLine("Hello, Server!");
writer.Flush();
writer.Close();
ns.Close();
client.Close();
