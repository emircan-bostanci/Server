namespace heliwars_server.Game;

public class Player{
    #region Player Information

    public int id {get;set;}
    public string name {get;set;}

    #endregion
    #region Stats

    public int health {get;set;}

    #endregion
    #region Positon

    public int positionX{get;set;}
    public int poisitonY{get;set;}
    public int rotation{get;set;}
    
    #endregion
}