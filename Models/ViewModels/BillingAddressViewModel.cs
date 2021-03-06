namespace BookCave.Models.ViewModels
{
    public class BillingAddressViewModel
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Country { get; set; }
        public string StateOrProvince { get; set; }
        public string City { get; set; }
        public string Zip {get; set;}
        public string StreetAddress { get; set; }
    }
}