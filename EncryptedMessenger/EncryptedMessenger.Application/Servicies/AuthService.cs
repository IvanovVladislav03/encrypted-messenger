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
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }
        public async Task<string> Login(string username, string password)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            if (!_passwordHasher.Verify(password, existingUser.PasswordHash))
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtService.Generate(existingUser.Username, existingUser.Id);
            return token;
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
