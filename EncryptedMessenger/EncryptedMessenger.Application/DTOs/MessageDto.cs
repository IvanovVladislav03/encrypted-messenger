using EncryptedMessenger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.DTOs
{
    public class MessageDto
    {
        public Guid UserId { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
