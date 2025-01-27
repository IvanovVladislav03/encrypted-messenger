using EncryptedMessenger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Interfaces
{
    public interface IChatRepository
    {
        Task<Chat> GetChatByIdAsync(Guid id);
        Task CreateChatAsync(Chat chat);
        Task SaveMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid chatId);
    }
}
