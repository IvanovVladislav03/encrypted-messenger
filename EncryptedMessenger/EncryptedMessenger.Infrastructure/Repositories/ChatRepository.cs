using AutoMapper;
using EncryptedMessenger.Application.DTOs;
using EncryptedMessenger.Domain.Interfaces;
using EncryptedMessenger.Domain.Models;
using EncryptedMessenger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMessenger.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ChatRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateChatAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
        }
        public async Task<Chat> GetChatByIdAsync(Guid id)
        {
            var chat = await _context.Chats
                .Include(c => c.Messages) // Загрузка связанных сообщений
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<Chat>(chat);
        }

        public async Task<IEnumerable<Chat>> GetChatsByUserId(Guid userId)
        {
            var chats = await _context.Chats
                .Include(c => c.ChatMembers)
                .Where(c => c.ChatMembers.Any(m => m.UserId == userId))
                .ToListAsync();

            return chats;
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid chatId)
        {
            var messages = await _context.Messages
                .Where(m => m.ChatId == chatId) 
                .ToListAsync();

            return _mapper.Map<IEnumerable<Message>>(messages);
        }


        public async Task SaveMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
