using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookCave.Models;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Data.EntityModels
{
    public class UsersShippingAddresses
    {
        public int Id { get; set; }
        [ForeignKey("AspNetUsers")]
        public string AspNetUserId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual ShippingAddresses Address { get; set; }
    }
}