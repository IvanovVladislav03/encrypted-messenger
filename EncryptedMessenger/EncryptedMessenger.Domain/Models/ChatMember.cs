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
        public Guid MemberId { get; set; }
        public required User Member { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
