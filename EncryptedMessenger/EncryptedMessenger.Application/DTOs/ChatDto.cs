using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.DTOs
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; } = string.Empty;
        public bool IsGroup { get; set; }
        public List<Guid> MemberIds { get; set; } = new();
    }

}
