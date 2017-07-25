using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_webapp.Util
{
    public class BaseController:System.Web.Mvc.Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admin"]==null)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}