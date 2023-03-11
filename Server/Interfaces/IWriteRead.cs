using System.Net.Sockets;

namespace heliwars_server.Server.Interfaces;

public interface IWriteRead{
    public byte[] Read();
    public void Write(byte[] data);
    public void SetNetworkStream(NetworkStream networkStream);

}