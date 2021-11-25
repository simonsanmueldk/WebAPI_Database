using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DataAcces
{
    public class AdultDbContext:DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Adult.db");
        }
    }
}