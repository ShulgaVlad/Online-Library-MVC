using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models;

namespace OnlineLibrary.Data
{
    public class OnlineLibraryDbContext:DbContext
    {
        public OnlineLibraryDbContext(DbContextOptions <OnlineLibraryDbContext> options):base(options) { 
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<HistoryOfReadBooks> HistoryOfReadBooks { get; set; }
        public DbSet<RegisteredReader> RegisteredReaders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
    }

}
