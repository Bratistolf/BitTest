using Bit.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bit.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BitContext>
    {
        public BitContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BitContext>();
            builder.UseSqlServer(configuration.GetConnectionString("MicrosoftSQLServerConnection"));
            return new BitContext(builder.Options);
        }
    }
}
