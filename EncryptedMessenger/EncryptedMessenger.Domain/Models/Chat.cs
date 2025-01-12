using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; } = string.Empty;
        public bool IsGroup { get; set; }
        public string PublicKey { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();

    }
}
