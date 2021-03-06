using System;

namespace BookCave.Models.ViewModels
{
    public class CardDetailsViewModel
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public int Cvc { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}