namespace Game.Core.Exceptions.Lobby;

public class LobbyNotFoundException : Exception
{
    public override string Message => "Lobby not found.";
}
