using EncryptedMessenger.Application.DTOs;
using EncryptedMessenger.Domain.Interfaces;
using EncryptedMessenger.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncryptedMessenger.WebAPI.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var userDto = new UserDto() { Username = user.Username, PublicKey = user.PublicKey };
            return Ok(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var usersDto = users.Select(u => new UserDto() { Username = u.Username, PublicKey = u.PublicKey });
            return Ok(usersDto);
        }


    }
}
