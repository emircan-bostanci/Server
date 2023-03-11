using System.Net.Sockets;
using heliwars_server.Server.Interfaces;

namespace heliwars_server.Server;

public sealed class WriteRead : IWriteRead
{
    private static WriteRead instance;
    private NetworkStream networkStream; 
    byte[] buffer = new byte[2048];

    public static WriteRead GetInstance(){
        if(instance == null)
            instance = new WriteRead();
        return instance;
    }
    public void SetNetworkStream(NetworkStream networkStream){
        this.networkStream = networkStream;
    }

    public byte[] Read(){
        if(networkStream == null){
            throw new NullReferenceException("Network Stream cannot be null");
        }
        networkStream.BeginRead(buffer,0,buffer.Length,ReadCallback,null);
        return buffer;
    }

    private void ReadCallback(IAsyncResult ar)
    {
       int readedBytes = networkStream.EndRead(ar); 
       if(readedBytes == 0){
        //TODO Disconnect
        return ;
       }
       while(networkStream.DataAvailable)
        Read();
        

    }

    public void Write(byte[] data)
    {
        if(networkStream == null){
            throw new NullReferenceException("Network Stream cannot be null");
        }
        networkStream.BeginWrite(data,0,data.Length,WriteCallback,null);
    }

    private void WriteCallback(IAsyncResult ar)
    {
        networkStream.EndWrite(ar);
    }
}