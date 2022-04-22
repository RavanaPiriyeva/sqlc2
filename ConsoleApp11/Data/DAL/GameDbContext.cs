using ConsoleApp11.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp11.Data.DAL
{
    class GameDbContext :DbContext

    {
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-V62NBK6;Database=StadiumGame;Trusted_Connection=TRUE;");
        }
    }
}
