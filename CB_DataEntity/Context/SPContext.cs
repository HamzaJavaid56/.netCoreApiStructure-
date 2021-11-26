using CB_DataEntity.Model;
using DataEntities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AF.DataEntities.Context
{
    public partial class SpContext : DbContext
    {
        public SpContext()
        {
        }
        public SpContext(DbContextOptions<SpContext> opt) : base(opt)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<Customers> Customers { get; set; }
       
        public virtual DbSet<Users> Users { get; set; }

    }
}
