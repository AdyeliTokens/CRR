using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using System.Web.Http;
using CRR.App_Start;

[assembly: OwinStartup(typeof(CRR.Startup))]
namespace CRR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            App_Start.Startup.ConfigureAuth(app);
            App_Start.Startup.ConfigureOAuth(app);

            WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);

            //app.MapSignalR();
        }
    }
}