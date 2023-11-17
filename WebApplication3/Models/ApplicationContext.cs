using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> books { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
