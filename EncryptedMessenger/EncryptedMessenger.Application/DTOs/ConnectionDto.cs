using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.DTOs
{
    public class ConnectionDto
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }

    }
}
