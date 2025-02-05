using EncryptedMessenger.Application.DTOs;
using EncryptedMessenger.Domain.Interfaces;
using EncryptedMessenger.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;
using System.Text.Json;

namespace EncryptedMessenger.WebAPI.Hubs
{
    public interface ICHatClient
    {
        public Task ReceiveMessage(MessageDto message);
    }
    public class ChatHub : Hub<ICHatClient>
    {
        private readonly IDistributedCache _cache;
        private readonly IChatRepository _chatrepository;
        public ChatHub(IDistributedCache cache, IChatRepository chatRepository)
        {
            _cache = cache;
            _chatrepository = chatRepository;

        }
        public async Task JoinChat(ConnectionDto connection)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatId.ToString());

            var connectionString = JsonSerializer.Serialize(connection);

            await _cache.SetStringAsync(Context.ConnectionId, connectionString);

        }

        public async Task SendMessage(string messageContent)
        {
            var connectionString = await _cache.GetAsync(Context.ConnectionId);

            var connection = JsonSerializer.Deserialize<ConnectionDto>(connectionString);

            if (connection is not null)
            {
                await Clients.Group(connection.ChatId.ToString()).ReceiveMessage(new MessageDto()
                {
                    MessageContent = messageContent,
                    Username = connection.Username,
                    CreatedAt = DateTime.Now
                });

                var message = new Message(connection.ChatId, connection.UserId, messageContent);

                await _chatrepository.SaveMessageAsync(message);
            }
        }
    }
}
