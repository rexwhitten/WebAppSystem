using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppSystem.Web.Middleware
{
    using System.Configuration;

    public class MiddlewareOptions
    {
        public String this[String KeyPath]
        {
            get
            {
                string value = null;

                if (ConfigurationManager.AppSettings.AllKeys.Contains(KeyPath))
                {
                    value = ConfigurationManager.AppSettings[KeyPath];
                }

                return value;
            }
        }
    }
}
