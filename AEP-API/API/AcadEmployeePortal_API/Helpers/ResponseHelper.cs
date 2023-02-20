using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ISMS_API.Helpers
{
    public static class ResponseHelper
    {
        public static IActionResult ComposeResponse(ModelStateDictionary ModelState, int statusCode, object data = null)
        {
            IActionResult result;
            switch (statusCode)
            {
                case 400: result = new BadRequestObjectResult(ModelState);
                          break;
                case 401: if (ModelState.Values.ToList()[0].Errors.Count != 0)
                            result = new UnauthorizedObjectResult(ModelState.Values.ToList()[0].Errors[0]);
                          else
                            result = new UnauthorizedObjectResult(ModelState.Values.ToList()[1].Errors);
                          break;
                case 404: if (ModelState.Values.ToList()[0].Errors.Count != 0)
                            result = new NotFoundObjectResult(ModelState.Values.ToList()[0].Errors);
                          else
                            result = new NotFoundObjectResult(ModelState.Values.ToList()[1].Errors);
                          break;
                default: result = new OkObjectResult(data);
                          break;
            }

            return result;
        }
    }
}