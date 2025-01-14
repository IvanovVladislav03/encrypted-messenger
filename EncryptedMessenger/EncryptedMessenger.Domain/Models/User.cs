using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class User
    {
        public User(string username, string passwordHash, string publicKey)
        {
            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordHash;
            PublicKey = publicKey;
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } 
        public string PublicKey { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Связи
        public ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
