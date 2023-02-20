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
    public class BarangayController : Controller
    {
        private IBarangayService _barangayService;

        public BarangayController(IBarangayService barangayService)
        {
            _barangayService = barangayService;
        }
        //Add Barangay Endpoint.
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddBarangay([FromBody] Barangay barangay)
        {
            string message = "";
            //check if model state is valid
            if (ModelState.IsValid)
            {
                //Executes when the model state is valid.
                try
                {
                    //Initialize BarangayHandler
                    BarangayHandler barangayHandler = new BarangayHandler(_barangayService);
                    //Validate if the barangay can be added.
                    ValidationResult error = barangayHandler.CanAddBarangay(barangay);
                    
                    if (error != null)
                        //Add ModelError in ModelState if there is an error.
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        //Add barangay
                        int status = _barangayService.AddBarangay(barangay);
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
        public async Task<IActionResult> UpdateBarangay([FromBody] Barangay barangay)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    BarangayHandler barangayHandler = new BarangayHandler(_barangayService);
                    error = barangayHandler.CanUpdateBarangay(barangay);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _barangayService.UpdateBarangay(barangay);
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
        public async Task<IActionResult> DeactivateBarangay(int barangayId)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    BarangayHandler barangayHandler = new BarangayHandler(_barangayService);
                    error = barangayHandler.CanCheckBarangay(barangayId);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _barangayService.DeactivateBarangay(barangayId);
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
        public async Task<IActionResult> ActivateBarangay(int barangayId)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    BarangayHandler barangayHandler = new BarangayHandler(_barangayService);
                    error = barangayHandler.CanCheckBarangay(barangayId);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _barangayService.ActivateBarangay(barangayId);
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
        public async Task<IActionResult> DeleteBarangay(int barangayId)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    BarangayHandler barangayHandler = new BarangayHandler(_barangayService);
                    error = barangayHandler.CanCheckBarangay(barangayId);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _barangayService.DeleteBarangay(barangayId);
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

        //url: api/Barangay/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<Barangay>> GetBarangayList()
        {
            return await _barangayService.GetBarangays().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetBarangay(int barangayId)
        {
            Barangay barangay = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    BarangayHandler barangayHandler = new BarangayHandler(_barangayService);
                    error = barangayHandler.CanCheckBarangay(barangayId);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        barangay = _barangayService.GetBarangay(barangayId);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, barangay));
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
