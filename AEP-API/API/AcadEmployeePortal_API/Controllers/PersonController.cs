using ISMS_API.Handlers;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PersonController : Controller
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try {
                    PersonHandler personHandler = new PersonHandler(_personService);
                    ValidationResult error = personHandler.CanAddPerson(person);
                    if (error != null)
                    {
                        ModelState.AddModelError(error.Key, error.Message);
                    }
                    else
                    {
                        int status = _personService.AddPerson(person);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 400));
        }
        [HttpPut(Routes.Edit)]
        public async Task<IActionResult> UpdatePerson([FromBody] Person Person)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    PersonHandler personHandler = new PersonHandler(_personService);
                    error = personHandler.CanUpdatePerson(Person);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _personService.UpdatePerson(Person);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return (error.StatusCode == 400) ? await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 400)) : await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 404));
        }

        [HttpPost(Routes.Deactivate)]
        public async Task<IActionResult> DeactivatePerson(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    PersonHandler PersonHandler = new PersonHandler(_personService);
                    error = PersonHandler.CanCheckPerson(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _personService.DeactivatePerson(id);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        [HttpPost(Routes.Activate)]
        public async Task<IActionResult> ActivatePerson(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    PersonHandler PersonHandler = new PersonHandler(_personService);
                    error = PersonHandler.CanCheckPerson(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _personService.ActivatePerson(id);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        [HttpDelete(Routes.Delete)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    PersonHandler PersonHandler = new PersonHandler(_personService);
                    error = PersonHandler.CanCheckPerson(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _personService.DeletePerson(id);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        //url: api/Person/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<Person>> GetPersonList()
        {
            return await _personService.GetPeople().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetPerson(int id)
        {
            Person Person = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    PersonHandler PersonHandler = new PersonHandler(_personService);
                    error = PersonHandler.CanCheckPerson(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        Person = _personService.GetPersonById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, Person));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }
    }

}
    
