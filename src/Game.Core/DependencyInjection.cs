using Game.Core.Services.Lobby;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddGameCore(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ILobbyService, LobbyService>();
        serviceCollection.AddSingleton<LobbiesManager>();

        return serviceCollection;
    }
}
