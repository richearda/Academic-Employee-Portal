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
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddRoom([FromBody] Room room)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    RoomHandler roomHandler = new RoomHandler(_roomService);
                    ValidationResult error = roomHandler.CanAddRoom(room);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomService.AddRoom(room);
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
        public async Task<IActionResult> UpdateRoom([FromBody] Room room)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomHandler roomHandler = new RoomHandler(_roomService);
                    error = roomHandler.CanUpdateRoom(room);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomService.UpdateRoom(room);
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
        public async Task<IActionResult> DeactivateRoom(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomHandler roomHandler = new RoomHandler(_roomService);
                    error = roomHandler.CanCheckRoom(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomService.DeactivateRoom(id);
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
        public async Task<IActionResult> ActivateRoom(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomHandler roomHandler = new RoomHandler(_roomService);
                    error = roomHandler.CanCheckRoom(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomService.ActivateRoom(id);
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
        public async Task<IActionResult> DeleteRoom(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomHandler roomHandler = new RoomHandler(_roomService);
                    error = roomHandler.CanCheckRoom(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _roomService.DeleteRoom(id);
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

        //url: api/Room/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<Room>> GetRoomList()
        {
            return await _roomService.GetRooms().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetRoom(int id)
        {
            Room room = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    RoomHandler roomHandler = new RoomHandler(_roomService);
                    error = roomHandler.CanCheckRoom(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        room = _roomService.GetRoomById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, room));
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
