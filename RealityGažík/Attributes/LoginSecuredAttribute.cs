using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RealityGažík.Attributes
{
    public class LoginSecuredAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) // po akci
        {

        }

        public void OnActionExecuting(ActionExecutingContext context) // před akcí
        {
            Controller controller = (Controller)context.Controller;

            if (controller.HttpContext.Session.GetInt32("login") != null)
            {
                context.Result = controller.RedirectToAction("index", "home");
            }
        }
    }
}
