using Pjatk.Tin.FitApp.Api.App_Start.Filters;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pjatk.Tin.FitApp.Api.Controllers
{
    [DbSessionInitializerFilter]
    public class BaseApiController : ApiController
    {
        public IDocumentSession DocumentSession { get; set; }


    }
}
