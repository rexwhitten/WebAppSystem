using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppSystem.Web.Middleware
{
    public class LogMiddleware : Microsoft.Owin.OwinMiddleware
    {
        public LogMiddleware(OwinMiddleware next, MiddlewareOptions options) :
            base(next)
        {
            this.Something = options["log/something"];
        }

        public override async Task Invoke(OwinRequest request, OwinResponse response)
        {
            var ipAddress = (string)request.Environment["server.RemoteIpAddress"];

            await Next.Invoke(request.Context);
        }

        public string Something { get; set; }
    }
}
