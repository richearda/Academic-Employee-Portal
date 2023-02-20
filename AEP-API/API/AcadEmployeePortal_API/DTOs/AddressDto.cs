using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class AddressDto
    {
        public int AddressID { get; set; }
        public AddressTypeDto AddressTypeName { get; set; }
        public string HouseBlkLotNo { get; set; }
        public string Street { get; set; }
        public string SubdivisionVillage { get; set; }
        public string Barangay { get; set; }
        public string CityMunicipality { get; set; }
        public string Province { get; set; }
        
        public PersonDto Person { get; set; }

    }
}
