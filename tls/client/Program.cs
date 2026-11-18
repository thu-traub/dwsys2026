using System.Net.Security;
using System.Net.Sockets;

const int Port = 12345;
Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
client.Connect("127.0.0.1", Port);
NetworkStream ns = new NetworkStream(client);
SslStream ssl = new SslStream(ns);
ssl.AuthenticateAsClient("server");
StreamWriter writer = new StreamWriter(ssl);
StreamReader reader = new StreamReader(ssl);
writer.WriteLine("time");
writer.Flush();
string? response = reader.ReadLine();
Console.WriteLine("Server response: " + response);
writer.Close();
reader.Close();
ns.Close();
client.Close();
