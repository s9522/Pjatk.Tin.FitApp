﻿using System.Web;
using System.Web.Http;

namespace Pjatk.Tin.FitApp.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
