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
    public class EvaluationCriteriaController : Controller
    {
              
            private IEvaluationCriteriaService _evaluationCriteriaService;

        public EvaluationCriteriaController(IEvaluationCriteriaService evaluationCriteriaService)
        {
            _evaluationCriteriaService = evaluationCriteriaService;
        }

            [HttpPost(Routes.Add)]
            public async Task<IActionResult> AddEvaluationCriteria([FromBody] EvaluationCriteria evaluationCriteria)
            {
                string message = "";

                if (ModelState.IsValid)
                {
                    try
                    {
                        EvaluationCriteriaHandler evaluationCriteriaHandler = new EvaluationCriteriaHandler(_evaluationCriteriaService);
                        ValidationResult error = evaluationCriteriaHandler.CanAddEvaluationCriteria(evaluationCriteria);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = _evaluationCriteriaService.AddEvaluationCriteria(evaluationCriteria);
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
            public async Task<IActionResult> UpdateEvaluationCriteria([FromBody] EvaluationCriteria EvaluationCriteria)
            {
                string message = "";
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EvaluationCriteriaHandler EvaluationCriteriaHandler = new EvaluationCriteriaHandler(_evaluationCriteriaService);
                        error = EvaluationCriteriaHandler.CanUpdateEvaluationCriteria(EvaluationCriteria);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = _evaluationCriteriaService.UpdateEvaluationCriteria(EvaluationCriteria);
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
            public async Task<IActionResult> DeactivateEvaluationCriteria(int id)
            {
                string message = "";
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EvaluationCriteriaHandler EvaluationCriteriaHandler = new EvaluationCriteriaHandler(_evaluationCriteriaService);
                        error = EvaluationCriteriaHandler.CanCheckEvaluationCriteria(id);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = _evaluationCriteriaService.DeactivateEvaluationCriteria(id);
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
            public async Task<IActionResult> ActivateEvaluationCriteria(int id)
            {
                string message = "";
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EvaluationCriteriaHandler EvaluationCriteriaHandler = new EvaluationCriteriaHandler(_evaluationCriteriaService);
                        error = EvaluationCriteriaHandler.CanCheckEvaluationCriteria(id);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = _evaluationCriteriaService.ActivateEvaluationCriteria(id);
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
            public async Task<IActionResult> DeleteEvaluationCriteria(int id)
            {
                string message = "";
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EvaluationCriteriaHandler EvaluationCriteriaHandler = new EvaluationCriteriaHandler(_evaluationCriteriaService);
                        error = EvaluationCriteriaHandler.CanCheckEvaluationCriteria(id);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = _evaluationCriteriaService.DeleteEvaluationCriteria(id);
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

            //url: api/EvaluationCriteria/getlist
            [HttpGet(Routes.GetList)]
            public async Task<IEnumerable<EvaluationCriteria>> GetEvaluationCriteriaList()
            {
                return await _evaluationCriteriaService.GetEvaluationCriterion().ToListAsync();
            }

            [HttpGet(Routes.Get)]
            public async Task<IActionResult> GetEvaluationCriteria(int id)
            {
                EvaluationCriteria EvaluationCriteria = null;
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EvaluationCriteriaHandler EvaluationCriteriaHandler = new EvaluationCriteriaHandler(_evaluationCriteriaService);
                        error = EvaluationCriteriaHandler.CanCheckEvaluationCriteria(id);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            EvaluationCriteria = _evaluationCriteriaService.GetEvaluationCriteria(id);
                            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, EvaluationCriteria));
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
