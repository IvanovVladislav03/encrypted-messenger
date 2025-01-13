using EncryptedMessenger.Domain.Interfaces;
using EncryptedMessenger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Application.Servicies
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        public AuthService(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public Task Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task Register(string username, string password, string publicKey)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("User already exists.");
            }

            string hashedPassword = _passwordHasher.Generate(password);

            var user = new User(username, hashedPassword, publicKey);

            await _userRepository.AddUserAsync(user);
        }
    }
}
