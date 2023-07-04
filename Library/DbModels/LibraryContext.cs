using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Diagnostics;

namespace Library.DbModels
{
    public class LibraryContext : DbContext

    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(
            options)
        { 
        }
        //public DbSet<Book> Books { get; set; }
        //public DbSet<BookDetail> BookDetails { get; set; } 
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Publisher> Publishers { get; set; }
        //public DbSet<Reader> Readers { get; set; }
        //public DbSet<BookReader> BookReaders { get; set; }

        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_Reader> Fluent_Readers { get; set; }
        public DbSet<Fluent_BookReader> Fluent_BookReaders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database = Library; Trusted_Connection = True; integrated security = true; TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FullName).IsRequired();    
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FullName).HasMaxLength(200);

            modelBuilder.Entity<Fluent_Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Description).HasMaxLength(200);
            modelBuilder.Entity<Fluent_Book>().HasOne(x=>x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            modelBuilder.Entity<Fluent_Book>().HasOne(x=>x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Fluent_BookDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.PagesCount).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(x => x.Book).WithOne(x => x.BookDetail).HasForeignKey<Fluent_BookDetail>(x=>x.BookId);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Address).HasMaxLength(100);

            modelBuilder.Entity<Fluent_BookReader>().HasKey(x => new { x.BookId, x.ReaderId });
            modelBuilder.Entity<Fluent_BookReader>().HasOne(x => x.Book).WithMany(x => x.BookReaders).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Fluent_BookReader>().HasOne(x => x.Reader).WithMany(x => x.BookReaders).HasForeignKey(x => x.ReaderId);
            modelBuilder.Entity<Fluent_BookReader>().ToTable("Fluent_BookReaders");

            //modelBuilder.Entity<BookReader>().HasKey(x => new { x.BookId, x.ReaderId });


        }

    }
}
