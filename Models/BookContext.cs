using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstSample.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }


}
