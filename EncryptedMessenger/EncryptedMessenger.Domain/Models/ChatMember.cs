using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class ChatMember
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public required Chat Chat { get; set; }
        public Guid UserId { get; set; }
        public required User User { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
