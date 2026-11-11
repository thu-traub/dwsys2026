using System.Net.Sockets;

const int Port = 12345;
Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
System.Net.IPEndPoint serverEP = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("255.255.255.255"), Port);
byte[] message = System.Text.Encoding.UTF8.GetBytes("UDP Message");
client.SendTo(message, serverEP);
client.Close();
