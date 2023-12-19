using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace RealityGažík.Controllers
{
    public abstract class BaseController : Controller
    {
        protected int id = 0;
        protected string role = "user";
        protected MyContext MyContext { get; set; } = new MyContext();
        public override void OnActionExecuting(ActionExecutingContext context) // volá se před každou akcí -- executed po každé akci
        {
            this.id = this.HttpContext.Session.GetInt32("login").GetValueOrDefault();
            this.role = this.HttpContext.Session.GetString("role")!;

            base.OnActionExecuting(context);

           this.ViewBag.Authenticated = this.HttpContext.Session.GetString("login") != null;
        }
    }
}
