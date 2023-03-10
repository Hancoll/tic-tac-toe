namespace Game.Core.Exceptions.Lobby;

public class NotAllPlayersAreReadyException : Exception
{
    public override string Message => "Not all players are ready.";
}
