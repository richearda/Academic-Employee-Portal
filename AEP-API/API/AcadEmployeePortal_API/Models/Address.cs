using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string HouseBlkLotNo { get; set; }
        public string Street { get; set; }
        public string SubdivisionVillage { get; set; }
        public int? BarangayId { get; set; }
        public int? CityMunicipalityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? AddressTypeID { get; set; }    
        public Person Person { get; set; }
        public virtual Barangay Barangay { get; set; }
        public virtual CityMunicipality CityMunicipality { get; set; }
        public virtual Province Province { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
