using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.Infrastructure.Repositories
{
    public class MessageLogRepository : IMessageLogRepository
    {
        private readonly FarmSightDbContext _context;

        public MessageLogRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<MessageLog> AddAsync(MessageLog message)
        {
            await _context.MessageLogs.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task DeleteAsync(MessageLog message)
        {
            _context.MessageLogs.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageLog>> GetAllAsync()
        {
            return await _context.MessageLogs.ToListAsync();
        }

        public async Task<MessageLog> GetByIdAsync(Guid id)
        {
            return await _context.MessageLogs.FindAsync(id);
        }

        public async Task<IEnumerable<MessageLog>> GetByFarmerIdAsync(Guid farmerId)
        {
            return await _context.MessageLogs
                .Where(m => m.FarmerId == farmerId)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<MessageLog>> GetByFieldIdAsync(Guid fieldId)
        {
            return await _context.MessageLogs
                .Where(m => m.FieldId == fieldId)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(MessageLog message)
        {
            _context.MessageLogs.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
