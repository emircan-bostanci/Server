namespace heliwars_server.Server.Parser;

public class Parser{
    int index = 0;
    byte[] package;
    public void Init(byte[] package){
        index = 0;
        this.package = package;
    }
    public int ReadNextInt(){
       byte[] convertTo = new byte[sizeof(int)];
       for(int i = 0; i < sizeof(int);i++){
         convertTo[i] = package[index];
         index += 1;
       } 
       return BitConverter.ToInt32(convertTo,0);
    }
    public float ReadNextFloat(){
       byte[] convertTo = new byte[sizeof(float)];
       for(int i = 0; i < sizeof(float);i++){
         convertTo[i] = package[index];
         index += 1;
       } 
       return (float)BitConverter.ToDouble(convertTo,0);
    }
    public void Clear(){
        index = 0;
        package = new byte[0];
    }
    
}