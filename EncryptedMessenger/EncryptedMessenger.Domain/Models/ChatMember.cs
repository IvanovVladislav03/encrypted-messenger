﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class ChatMember
    {

        public Guid Id { get; set; }
        public Guid ChatId { get; set; }

        [JsonIgnore]
        public Chat Chat { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } 
        public DateTime AddedAt { get; set; }
    }
}
