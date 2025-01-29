using EncryptedMessenger.Application.DTOs;
using EncryptedMessenger.Domain.Interfaces;
using EncryptedMessenger.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncryptedMessenger.WebAPI.Controllers
{
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public ChatController(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserChats(Guid userId)
        {
            var chats = await _chatRepository.GetChatsByUserId(userId);
            return Ok(chats);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatDto createChatDto)
        {
            var chat = new Chat(createChatDto.ChatName, createChatDto.PublicKey, createChatDto.ChatMembers.Count > 2 ? true : false);
            var chatMembers = new List<ChatMember>();
            foreach (var memberId in createChatDto.ChatMembers)
            {
                var chatMember = new ChatMember()
                {
                    Id = Guid.NewGuid(),
                    ChatId = chat.Id,
                    UserId = (await _userRepository.GetUserByUsernameAsync(memberId)).Id,
                    AddedAt = DateTime.UtcNow,
                };
                chatMembers.Add(chatMember);
            }
            chat.ChatMembers = chatMembers;
            await _chatRepository.CreateChatAsync(chat);
            return Ok(chat);
        }
    }
}
