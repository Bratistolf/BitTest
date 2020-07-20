using Microsoft.EntityFrameworkCore;
using Bit.Api.Domain.Entities;

namespace Bit.Api.Database
{
    public class BitContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public BitContext(DbContextOptions<BitContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
