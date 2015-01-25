using Pjatk.Tin.FitApp.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Pjatk.Tin.FitApp.Api.App_Start.Filters
{
    public class DbSessionInitializerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as BaseApiController;
            if (controller.DocumentSession!=null)
            {
                controller.DocumentSession = RavenDbConfig.Store.OpenSession();
                base.OnActionExecuting(actionContext);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as BaseApiController;
            if (controller.DocumentSession != null && actionExecutedContext.Exception == null)
                controller.DocumentSession.SaveChanges();
            controller.DocumentSession.Dispose();
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}