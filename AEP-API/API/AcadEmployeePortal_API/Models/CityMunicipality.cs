using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class CityMunicipality
    {
        public int CityMunicipalityId { get; set; }
        public string CityMunicipalityName { get; set; }
        public bool? IsCity { get; set; }
        public string ZipCode { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        //Navigation Properties
        //public virtual ICollection<Person> PersonPermanentCityMunicipalityNavigations { get; set; }
       // public virtual ICollection<Person> PersonResidentialCityMunicipalityNavigations { get; set; }
    }
}
