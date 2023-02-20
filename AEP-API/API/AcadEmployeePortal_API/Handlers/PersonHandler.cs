using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class PersonHandler
    {

        private IPersonService _personService;

        public PersonHandler(IPersonService personService)
        {
            _personService = personService;
        }
        //Validate if the Person already exist or the required field contains value.
        public ValidationResult CanAddPerson(Person person)
        {
            ValidationResult result = null;
            if (person.FirstName != null || person.FirstName != "")
            {
                if ((person.LastName != null || person.LastName != ""))
                {
                    Person personName = _personService.GetPersonById(person.PersonId);
                    if (_personService.IsPersonExist(personName))
                        result = new ValidationResult("Person's Name", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Person's Last Name", "Required", 400);
            }
            else
                result = new ValidationResult("Person's First Name", "Required", 400);
            return result;
        }

        public ValidationResult CanUpdatePerson(Person person)
        {
            ValidationResult result = null;
            Person checkPerson = _personService.GetPersonById(person.PersonId);

            if (checkPerson != null)
            {
                if (person.FirstName == null || person.FirstName == "")
                    result = new ValidationResult("Person's First Name", "Required", 400);
                else if ((person.LastName == null || person.LastName == ""))
                    result = new ValidationResult("Person's Last Name", "Required", 400);
                else if ((person.FirstName.Equals(checkPerson.FirstName,StringComparison.OrdinalIgnoreCase) && person.LastName.Equals(checkPerson.LastName)))
                {
                    //if (_personService.IsPersonExist(person)) ;                    
                        //result = new ValidationResult("Person", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        //Validate if the Person exist.
        public ValidationResult CanCheckPerson(int personID)
        {
            ValidationResult result = null;
            Person Person = _personService.GetPersonById(personID);
            if (Person == null)
                result = new ValidationResult("Error", "Person does not exist.", 404);
            return result;
        }



    }
}
