using System.Web.Http;
using Pjatk.Tin.FitApp.Api.Filters;
using Raven.Client;

namespace Pjatk.Tin.FitApp.Api.Controllers
{
    [DbSessionInitializerFilter]
    public class BaseApiController : ApiController
    {
        public IDocumentSession DocumentSession { get; set; }


    }
}
