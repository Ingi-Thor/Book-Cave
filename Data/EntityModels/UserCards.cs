using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookCave.Models;
using BookCave.Data.EntityModels;


namespace BookCave.Data.EntityModels
{
    public class UserCards
    {
        public int Id { get; set; }
        [ForeignKey("AspNetUsers")]
        public string AspNetUsersId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public virtual CardDetails Card { get; set; }
    
    }
}