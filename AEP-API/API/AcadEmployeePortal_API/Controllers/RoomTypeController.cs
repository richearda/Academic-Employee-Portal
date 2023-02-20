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
    public class RoomTypeController : Controller
    {
        private IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddRoomType([FromBody] RoomType roomType)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    RoomTypeHandler roomTypeHandler = new RoomTypeHandler(_roomTypeService);
                    ValidationResult error = roomTypeHandler.CanAddRoomType(roomType);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomTypeService.AddRoomType(roomType);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200));
        }

        [HttpPut(Routes.Edit)]
        public async Task<IActionResult> UpdateRoomType([FromBody] RoomType roomType)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomTypeHandler roomTypeHandler = new RoomTypeHandler(_roomTypeService);
                    error = roomTypeHandler.CanUpdateRoomType(roomType);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomTypeService.UpdateRoomType(roomType);
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
        public async Task<IActionResult> DeactivateRoomType(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomTypeHandler roomTypeHandler = new RoomTypeHandler(_roomTypeService);
                    error = roomTypeHandler.CanCheckRoomType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomTypeService.DeactivateRoomType(id);
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
        public async Task<IActionResult> ActivateRoomType(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomTypeHandler roomTypeHandler = new RoomTypeHandler(_roomTypeService);
                    error = roomTypeHandler.CanCheckRoomType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomTypeService.ActivateRoomType(id);
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
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomTypeHandler roomTypeHandler = new RoomTypeHandler(_roomTypeService);
                    error = roomTypeHandler.CanCheckRoomType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomTypeService.DeleteRoomType(id);
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

        //url: api/RoomType/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<RoomType>> GetRoomTypeList()
        {
            return await _roomTypeService.GetRoomTypes().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetRoomType(int id)
        {
            RoomType roomType = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomTypeHandler roomTypeHandler = new RoomTypeHandler(_roomTypeService);
                    error = roomTypeHandler.CanCheckRoomType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        roomType = _roomTypeService.GetRoomTypeById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, roomType));
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
