using Bit.Api.Domain.Entities;
using Bit.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.Api.Services
{
    public class MockRepository : IRepository<Player>
    {
        private readonly List<Player> Players = new List<Player>
        {
            new Player
            {
                PlayerId = 0,
                Name = "Иван",
                Surname = "Иванов",
                Gender = "Мужчина",
                Birthday = "10/10/1990",
                TeamId = 0,
                Country = "Россия"
            },
            new Player
            {
                PlayerId = 1,
                Name = "Василий",
                Surname = "Сидоров",
                Gender = "Мужчина",
                Birthday = "10/10/1990",
                TeamId = 0,
                Country = "Россия"
            },
            new Player
            {
                PlayerId = 2,
                Name = "Александр",
                Surname = "Петров",
                Gender = "Мужчина",
                Birthday = "10/10/1990",
                TeamId = 0,
                Country = "Россия"
            }
        };

        public MockRepository()
        {

        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return Players;
        }

        public async Task<Player> GetAsync(int id)
        {
            return Players.FirstOrDefault(x => x.PlayerId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //Do something...
            return true;
        }

        public void Create(Player entity)
        {
            //Do something...
        }

        public void Update(Player entity)
        {
            //Do something...
        }

        public void Delete(Player entity)
        {
            //Do something...
        }
    }
}
