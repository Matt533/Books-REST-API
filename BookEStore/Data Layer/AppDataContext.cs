using BookEStore.Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookEStore.Data_Layer
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18, 2)"); 
        }
    }
   
}
