using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public required Message Message { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
