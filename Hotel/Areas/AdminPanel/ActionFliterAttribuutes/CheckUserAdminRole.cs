using Hotel.Application.Extensions;
using Hotel.Application.Services.Implement;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Account;
using Hotel.Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hotel.Areas.AdminPanel.ActionFliterAttribuutes;

public class CheckUserAdminRole : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var Service = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService))!;
        base.OnActionExecuting(context);

        #region دسترسی داشتن کاربر


        var Result = Service.IsUserAdmin((int)context.HttpContext.User.GetUserId());
        if (Result == false)
        {
            context.HttpContext.Response.Redirect("/");
        }

        #endregion

    }
}

