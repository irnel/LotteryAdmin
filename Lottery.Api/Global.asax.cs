using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Data.Entity;

namespace Lottery.Infrastructure
{
    /// <summary>
    /// WebApiApplication
    /// </summary>
    /// 
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Application start
        /// </summary>
        /// 
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }
    }
}
