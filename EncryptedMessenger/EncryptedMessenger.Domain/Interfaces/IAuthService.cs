﻿using EncryptedMessenger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Domain.Interfaces
{
    internal interface IAuthService
    {
        Task Login(string userName, string password);
        Task Register(string userName, string password);
    }
}