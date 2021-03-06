using System.Collections.Generic;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class ShippingAddressService
    {
        private ShippingAddressRepo _shippingAddressRepo;

        private DataContext _db;

        public ShippingAddressService()
        {
            _shippingAddressRepo = new ShippingAddressRepo();
            _db = new DataContext();
        }

        public ShippingAddressViewModel GetByAddressId(int addressId)
        {
            return _shippingAddressRepo.GetByAddressId(addressId);
        }
        public List<ShippingAddressViewModel> GetByUserId(string userId)
        {
            return _shippingAddressRepo.GetByUserId(userId);
        }

        public void Write(ShippingAddresses shippingAddress)
        {
            _shippingAddressRepo.Write(shippingAddress);
        }

        public void Remove(ShippingAddresses shippingAddress)
        {
            _shippingAddressRepo.Remove(shippingAddress);
        }
    }
}