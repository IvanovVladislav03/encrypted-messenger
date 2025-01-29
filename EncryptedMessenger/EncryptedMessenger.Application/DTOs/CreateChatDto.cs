using EncryptedMessenger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.DTOs
{
    public class CreateChatDto
    {
        public string ChatName { get; set; }
        public string PublicKey { get; set; } = string.Empty;
        public List<string> ChatMembers { get; set; } = new List<string>();
    }
}
