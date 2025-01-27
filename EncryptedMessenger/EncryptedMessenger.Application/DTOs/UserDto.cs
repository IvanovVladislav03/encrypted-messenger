using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }

        public string PublicKey { get; set; }
    }
}
