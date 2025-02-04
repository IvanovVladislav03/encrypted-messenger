using EncryptedMessenger.Application.DTOs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace EncryptedMessenger.WebAPI.Hubs
{
    public interface ICHatClient
    {
        public Task ReceiveMessage(string username, string message);
    }
    public class ChatHub : Hub<ICHatClient>
    {
        private readonly IDistributedCache _cache;
        public ChatHub(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task JoinChat(ConnectionDto connection)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatName);

            var connectionString = JsonSerializer.Serialize(connection);
            await _cache.SetStringAsync(Context.ConnectionId, connectionString);

            await Clients.Group(connection.ChatName).ReceiveMessage(connection.Username, $"{connection.Username} подключился к чату");
        }

        public async Task SendMessage(string message)
        {
            var connectionString = await _cache.GetAsync(Context.ConnectionId);

            var connection = JsonSerializer.Deserialize<ConnectionDto>(connectionString);

            if (connection is not null)
            {
                await Clients.Group(connection.ChatName).ReceiveMessage(connection.Username, message);
            }
        }
    }
}
