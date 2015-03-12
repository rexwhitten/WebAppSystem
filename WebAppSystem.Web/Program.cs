using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppSystem.Web
{
    // https://github.com/titarenko/OAuth2

    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:999/";

            if (args.Any())
            {
                uri = args;
            }

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopped");
            }
        }
    }
}
