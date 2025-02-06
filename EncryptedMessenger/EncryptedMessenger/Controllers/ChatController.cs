using EncryptedMessenger.Application.DTOs;
using EncryptedMessenger.Domain.Interfaces;
using EncryptedMessenger.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        [HttpGet]
        public async Task<IActionResult> GetUserChats()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                throw new UnauthorizedAccessException("User is not authenticated or has invalid identifier.");

            var chats = await _chatRepository.GetChatsByUserId(new Guid(userId));

            

            var chatsDto = chats.Select(c => new ChatViewDto()
            {
                Id = c.Id,
                ChatName = c.ChatName,
                IsGroup = c.IsGroup,
            });

            return Ok(chatsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChat(Guid id)
        {
            var chat = await _chatRepository.GetChatByIdAsync(id);

            var messages = await _chatRepository.GetMessagesByChatIdAsync(id);

            var messagesDto = messages.Select(m => new MessageDto()
            {
                Username = m.User.Username,
                MessageContent = m.MessageContent,
                CreatedAt = m.CreatedAt,
                Attachments = m.Attachments,
            }).ToList();

            var chatsDto = new ChatContentDto()
            {
                ChatId = chat.Id,
                MemberIds = chat.ChatMembers.Select(c => c.Id).ToList(),
                Messages = messagesDto
            };

            return Ok(chatsDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatDto createChatDto)
        {
            var chat = new Chat(createChatDto.ChatName, createChatDto.PublicKey, createChatDto.ChatMembers.Count > 2 ? true : false);
            var chatMembers = new List<ChatMember>();
            foreach (var memberName in createChatDto.ChatMembers)
            {
                var chatMember = new ChatMember()
                {
                    Id = Guid.NewGuid(),
                    ChatId = chat.Id,
                    UserId = (await _userRepository.GetUserByUsernameAsync(memberName)).Id,
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
