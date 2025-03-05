using Microsoft.EntityFrameworkCore;


namespace EF_Core_Day1
{
    public class LibraryContext :DbContext
    {
        //Tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Auther> Authers { get; set; }

        //Connection string
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = DESKTOP-0KJMNFC; Initial catalog = Library; Integrated security= true; trustservercertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
