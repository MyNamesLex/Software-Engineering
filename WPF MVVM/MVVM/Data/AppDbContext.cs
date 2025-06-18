using Microsoft.EntityFrameworkCore;
using MVVM.Model;

namespace MVVM.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;");
        }
    }
}
