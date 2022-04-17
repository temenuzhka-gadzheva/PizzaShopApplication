using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PizzaShop.Core.SessionHelper;
using PizzaShop.Models.Models;

namespace PizzaShop.Core.Authentication
{
    public class AuthenticationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.HttpContext.Session.GetObjectFromJson<User>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Register");

        }
    }
}
