using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Person
    {     
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MaidenName { get; set; }
        public string NameExtension { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? CivilStatusId { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public int? Age { get; set; }
        public string Birthplace { get; set; }
        public DateTime? Birthdate { get; set; }
        //public double? Height { get; set; }
        //public double? Weight { get; set; }
        //public int? BloodTypeId { get; set; }
        public int? CitizenshipId { get; set; }
        public Citizenship Citizenship { get; set; }
        //public int? DualCitizenshipAcquisitionId { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public  bool? IsActive { get; set; }
        public  string PictureLink { get; set; }
        public virtual ICollection<PersonUser> PersonUsers { get; set; }
        public Dean Dean { get; set; }
        public virtual Employee Employee { get; set; }
        public Teacher Teacher { get; set; }

        

    }
}
