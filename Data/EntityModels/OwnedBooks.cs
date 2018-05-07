using System.ComponentModel.DataAnnotations.Schema;
using BookCave.Models;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Data.EntityModels
{
    public class OwnedBooks
    {
        public int Id { get; set; }
         [ForeignKey("AspNetUsers")]
        public string AspNetUsersId { get; set; }
        public virtual IdentityUser AspNetUsers { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}