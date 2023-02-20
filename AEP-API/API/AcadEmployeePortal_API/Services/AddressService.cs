using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class AddressService : IAddressService
    {
        private EmpPortalDbContext _dbContext;
        public AddressService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        public int AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public int DeactivateAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public int DeleteAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Address> GetAddresses()
        {
            throw new NotImplementedException();
        }

        public bool IsAddressExist(Address dddress)
        {
            throw new NotImplementedException();
        }

        public int UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
