using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAppSystem.Web.Controllers
{
    [Authorize]
    [RoutePrefix("/sys")]
    public class SysController : ApiController
    {
        #region [ Constructor ]
        public SysController()
            : base()
        {

        }
        #endregion

        public String Get()
        {
            return "Web Application System 1";
        }
    }
}
