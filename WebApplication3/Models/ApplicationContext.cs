
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using LibraryProject.Areas.Identity.Data;

namespace LibraryProject.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> books { get; set; } = null!;
        // public DbSet<LibraryUser> users { get; set; }
        // public DbSet<LibraryUser> LibraryUsers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Другие настройки модели
            //modelBuilder.Entity<LibraryUser>().ToTable("LibraryUsers");
            //modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            //});


            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            //});
        }

    }
}
