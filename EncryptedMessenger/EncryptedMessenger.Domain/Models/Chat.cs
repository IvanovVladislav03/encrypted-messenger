﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; } = string.Empty;
        public bool IsGroup { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
