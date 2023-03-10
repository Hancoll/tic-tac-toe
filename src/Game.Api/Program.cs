using Game.Api.Hubs;
using Game.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGameCore();
builder.Services.AddControllers();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapControllers();
app.MapHub<LobbyHub>("/lobbyHub");

app.Run();
