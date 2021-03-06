using Microsoft.EntityFrameworkCore;
using BookCave.Data.EntityModels;
namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AspNetUsers> AspNetUsers {get;set;}
        public DbSet<Authors> Authors {get; set;}
        public DbSet<BillingAddresses> BillingAddress {get; set;}
        public DbSet<Books> Books {get; set;}
        public DbSet<BooksAuthors> BooksAuthors {get;set;}
        public DbSet<BooksGenres> BookGenres {get;set;}
        public DbSet<BooksLanguages> BooksLanguages { get; set; }
        public DbSet<CardDetails> CardDetails {get; set;}
        public DbSet<Countries> Countries {get; set;}
        public DbSet<Feedbacks> Feedbacks {get; set;}
        public DbSet<Formats> Formats {get; set;}
        public DbSet<Genres> Genres {get; set;}
        public DbSet<Languages> Languages {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<OrdersBooks> OrdersBooks { get; set; }
        public DbSet<OwnedBooks> OwnedBooks {get;set;}
        public DbSet<ReadBooks> ReadBooks {get;set;}
        public DbSet<Reviews> Reviews {get; set;}
        public DbSet<ShippingAddresses> ShippingAddresses { get; set; }
        public DbSet<UsersWishlists> UsersWishlists {get;set;}
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H01;Persist Security Info=False;User ID=VLN2_2018_H01_usr;Password=cut3Rose64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}