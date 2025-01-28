using Microsoft.AspNetCore.SignalR;

namespace EncryptedMessenger.WebAPI.Hubs
{
    public interface ICHatClient
    {
        public Task ReceiveMessage(string username, string message);
    }
    public class ChatHub : Hub<ICHatClient>
    {
        public async Task JoinChat(string userName, string chatName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatName);

            await Clients.Group(chatName).ReceiveMessage(userName, $"{userName} подключился к чату");
        }
    }
}
