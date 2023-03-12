using System.Net.Sockets;
using heliwars_server.Server.Interfaces;

namespace heliwars_server.Server;
public class TCP{
    TcpListener tcpListener;
    readonly int PORT ;
    public int _PORT{get{
        return this.PORT;
    }}
    public TCP(int PORT)
    {
        this.PORT = PORT;
    }

    public void initServer(){
        Console.WriteLine("Server Beginning");
        
         tcpListener = new TcpListener(System.Net.IPAddress.Any,PORT);
         tcpListener.Start();
    }
    public void Accept(){
        AcceptClients.GetInstance().AcceptClient(tcpListener);
        //First read get ID, Position, Name, Hp and Rotation
    }
    public void Read(){
        var clients =  AcceptClients.GetInstance().clients;
        Console.WriteLine(clients.Count);
        foreach(var i in clients){
            WriteRead.GetInstance().SetNetworkStream(i.GetStream());
            WriteRead.GetInstance().Read(); 
            Console.WriteLine("AAAAAAAAa");
        }
    }
    public void Write(){

    }
   
}