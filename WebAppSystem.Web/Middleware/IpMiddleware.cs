using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppSystem.Web.Middleware
{
    public class IpMiddleware : OwinMiddleware
    {
        private readonly HashSet<string> _deniedIps;

        public IpMiddleware(OwinMiddleware next, HashSet<string> deniedIps) :
            base(next)
        {
            _deniedIps = deniedIps;
        }

        public override async Task Invoke(OwinRequest request, OwinResponse response)
        {
            var ipAddress = (string)request.Environment["server.RemoteIpAddress"];

            if (_deniedIps.Contains(ipAddress))
            {
                response.StatusCode = 403;
                return;
            }

            await Next.Invoke(request.Context);
        }
    }
}
