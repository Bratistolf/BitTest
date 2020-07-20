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
    public class TeamRepository : IRepository<Team>
    {
        private readonly BitContext _context;

        public TeamRepository(BitContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToArrayAsync();
        }

        public async Task<Team> GetAsync(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.TeamId == id);
            if (team == null)
            {
                throw new NotFoundException($"Команда с ID = {id} не была найдена");
            }
            return team;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var savingResult = await _context.SaveChangesAsync();
            return savingResult > 0;
        }

        public void Create(Team entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Add(entity);
        }

        public void Update(Team entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Update(entity);
        }

        public void Delete(Team entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Remove(entity);
        }
    }
}
