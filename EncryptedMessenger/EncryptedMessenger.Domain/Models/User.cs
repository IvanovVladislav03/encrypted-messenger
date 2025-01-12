﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Связи
        public ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
