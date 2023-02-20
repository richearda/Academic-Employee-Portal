using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace EmployeePortal.Helper
{
    public class AuthorizationFilter:AuthorizeAttribute, System.Web.Mvc.IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }
            
            // Check for authorization
            //if (System.Web.HttpContext.Current.Session["Username"] == null)
            //{
            //    filterContext.Result = new HttpUnauthorizedResult();
            //}
        }
    }
}
