using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.DTOs
{
    public class ChatContentDto
    {
        public Guid ChatId { get; set; }
        public List<UserDto> Members { get; set; } = new();
        public List<MessageDto> Messages { get; set; } = new();
    }
}
