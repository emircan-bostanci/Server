namespace heliwars_server.Server.Interfaces;

public interface IConnection<T>{
    public void AcceptClient(T listenerType);

}