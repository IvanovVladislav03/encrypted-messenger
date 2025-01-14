using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Interfaces
{
    public interface IJwtService
    {
        public string Generate(string username, Guid id);

    }
}
