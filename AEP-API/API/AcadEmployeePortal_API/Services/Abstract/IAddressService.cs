using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IAddressService
    {
        IQueryable<Address> GetAddresses();
        int AddAddress(Address address);
        int UpdateAddress(Address address);
        int DeleteAddress(int addressId);
        bool IsAddressExist(Address dddress);
        Address GetAddress(int addressId);
    }
}
