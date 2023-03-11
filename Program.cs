// See https://aka.ms/new-console-template for more information
using heliwars_server.Server;

Console.WriteLine("Server Starting!");

TCP tcp = new TCP(8816);
tcp.initServer();
Task.Run(()=>{
        tcp.Accept();
});

Console.ReadKey();