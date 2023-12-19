using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models.Database;

namespace RealityGažík.Attributes
{
    public class BrokerSecuredAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) // po akci
        {

        }

        public void OnActionExecuting(ActionExecutingContext context) // před akcí
        {
            Controller controller = (Controller)context.Controller;

            if (controller.HttpContext.Session.GetInt32("login") == null 
                || controller.HttpContext.Session.GetString("role") == Roles.user)
            {
                context.Result = controller.RedirectToAction("index", "login");
            }
        }
    }
}
