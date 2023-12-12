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
        protected bool isAdmin = false;
        protected bool isUser = false;
        protected MyContext MyContext { get; set; } = new MyContext();
        public override void OnActionExecuting(ActionExecutingContext context) // volá se před každou akcí -- executed po každé akci
        {
            this.id = this.HttpContext.Session.GetInt32("login").GetValueOrDefault();
            this.isUser = Convert.ToBoolean(this.HttpContext.Session.GetString("isuser"));
            this.isAdmin = Convert.ToBoolean(this.HttpContext.Session.GetString("isadmin"));

            base.OnActionExecuting(context);

           this.ViewBag.Authenticated = this.HttpContext.Session.GetString("login") != null;
        }
    }
}
