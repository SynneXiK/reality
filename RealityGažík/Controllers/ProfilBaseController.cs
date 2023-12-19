using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RealityGažík.Models;

namespace RealityGažík.Controllers
{
    public abstract class ProfilBaseController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext context) // volá se před každou akcí -- executed po každé akci
        {
            base.OnActionExecuting(context);

            this.ViewBag.role = this.role;
        }
    }
}
