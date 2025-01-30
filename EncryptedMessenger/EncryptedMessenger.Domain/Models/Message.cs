using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class Message
    {
        public Message(Guid chatId, Guid userId, string messageContent)
        {
            Id = Guid.NewGuid();
            ChatId = chatId;
            UserId = userId;
            MessageContent = messageContent;
        }
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public required Chat Chat { get; set; }
        public Guid UserId { get; set; }
        public required User User { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
