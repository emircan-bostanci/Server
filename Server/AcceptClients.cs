using System.Net.Sockets;
using heliwars_server.Server.Interfaces;

namespace heliwars_server.Server;

public class AcceptClients : IConnection<TcpListener>
{
    public List<TcpClient> clients = new List<TcpClient>();
   #region  Singleton
       private AcceptClients(){

       } 
       private static AcceptClients instance;
       public static AcceptClients GetInstance(){
        if(instance == null){
            instance = new AcceptClients();
        }
        return instance;
       }


    #endregion
    public void AcceptClient(TcpListener listenerType)
    {
        listenerType.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback),listenerType);       
    }

    private void AcceptTcpClientCallback(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        TcpClient client = listener.EndAcceptTcpClient(ar);
        Console.WriteLine("New Connection From "+ ((uint)client.Client.RemoteEndPoint.AddressFamily));
        clients.Add(client);
        listener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback),listener); 
    }
}