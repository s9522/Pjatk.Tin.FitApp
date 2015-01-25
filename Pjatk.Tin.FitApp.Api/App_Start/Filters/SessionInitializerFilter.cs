using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ninject;
using Pjatk.Tin.FitApp.Api.Controllers;
using Raven.Client;

namespace Pjatk.Tin.FitApp.Api.Filters
{
    public class DbSessionInitializerFilter : ActionFilterAttribute
    {
        [Inject]
        public IDocumentSession DocumentSession { get; set; }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var controller = actionContext.ControllerContext.Controller as BaseApiController;
            if (controller != null && controller.DocumentSession == null)
            {
                controller.DocumentSession = DocumentSession;                
            }
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as BaseApiController;
            if (controller != null && controller.DocumentSession != null)
            {
                controller.DocumentSession = DocumentSession;
                base.OnActionExecuting(actionContext);
            }
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as BaseApiController;
            if (controller != null && (controller.DocumentSession != null && actionExecutedContext.Exception == null))
            {
                controller.DocumentSession.SaveChanges();
                controller.DocumentSession.Dispose();
            }
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as BaseApiController;
            if (controller != null && (controller.DocumentSession != null && actionExecutedContext.Exception == null))
            {
                controller.DocumentSession.SaveChanges();
                controller.DocumentSession.Dispose();
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}