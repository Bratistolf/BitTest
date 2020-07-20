using Microsoft.EntityFrameworkCore;
using Bit.Api.Database;
using Bit.Api.Domain.Entities;
using Bit.Api.Helpers.Exceptions;
using Bit.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.Api.Services
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly BitContext _context;

        public PlayerRepository(BitContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToArrayAsync();
        }

        public async Task<Player> GetAsync(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.PlayerId == id);
            if (player == null)
            {
                throw new NotFoundException($"Игрок с ID = {id} не был найден");
            }
            return player;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var savingResult = await _context.SaveChangesAsync();
            return savingResult > 0;
        }

        public void Create(Player entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Add(entity);
        }

        public void Update(Player entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Update(entity);
        }

        public void Delete(Player entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Remove(entity);
        }
    }
}
