using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public required Chat Chat { get; set; }
        public Guid SenderId { get; set; }
        public required User Sender { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
