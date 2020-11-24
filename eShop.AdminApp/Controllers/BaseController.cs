using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eShop.AdminApp.Controllers
{
    public class BaseController : Controller
    {
        //Kiểm tra session có tồn tại hay không. Phương thức này đc gọi đầu tiên trong Controller
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            if (String.IsNullOrEmpty(sessions))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuted(context);
        }
    }
}