namespace Game.Core.Exceptions.Lobby;

public class LobbyIsFullException : Exception
{
    public override string Message => "Lobby is full.";
}
