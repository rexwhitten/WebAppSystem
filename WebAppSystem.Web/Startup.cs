using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAppSystem.Web.Middleware;

namespace WebAppSystem.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Middleware
            var deniedIps = new HashSet<string> { "192.168.0.100", "192.168.0.101" }; // load from config

            app.Use(typeof(IpMiddleware), deniedIps);
            app.Use(typeof(LogMiddleware), new MiddlewareOptions());

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                         name: "DefaultApi",
                         routeTemplate: "api/{controller}/{id}",
                         defaults: new { id = RouteParameter.Optional }
                     );

            app.UseWebApi(config);
        }
    }
}
