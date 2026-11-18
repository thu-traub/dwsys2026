using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

const int Port = 12345;
X509Certificate crt = new X509Certificate(@"server.pfx", "abc");
Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
server.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
server.Listen(1);
Console.WriteLine("Server is listening on port " + Port);
while (true) {
    Socket client = server.Accept();
    Console.WriteLine("Client connected.");
    NetworkStream ns = new NetworkStream(client);
    SslStream ssl = new SslStream(ns);
    ssl.AuthenticateAsServer(crt);    
    StreamReader reader = new StreamReader(ssl);
    StreamWriter writer = new StreamWriter(ssl);
    string? line = reader.ReadLine();
    switch (line)
    {
        case "time":
            writer.WriteLine(DateTime.Now.ToString());
            writer.Flush();
            break;
        default:
            writer.WriteLine("Unknown command");
            writer.Flush();
            break;
    }
    reader.Close();
    ns.Close();
    client.Close();
}
// server.Close();