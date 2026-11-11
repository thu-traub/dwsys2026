using System.Net.Sockets;

const int Port = 12345;
Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
server.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
Console.WriteLine("Server is listening on port " + Port);
while (true) {
    byte[] buffer = new byte[1024];
    System.Net.EndPoint remoteEP = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
    int received = server.ReceiveFrom(buffer, ref remoteEP);
    string message = System.Text.Encoding.UTF8.GetString(buffer, 0, received);
    Console.WriteLine("Received from " + remoteEP.ToString() + ": " + message);
}
// server.Close();