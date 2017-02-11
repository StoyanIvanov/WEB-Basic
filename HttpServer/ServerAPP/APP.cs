using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpServer.Enums;
using HttpServer.Models;

namespace ServerAPP
{
    public class APP
    {
        static void Main()
        {
            var routes = new List<Route>()
            {
               new Route()
               {
                   Name="Hello Handler",
                   UrlRegex = @"^/hello$",
                   Method = RequestMethod.GET,
                   Callable = (HttpRequest request) =>
                   {
                       return new HttpResponse()
                       {
                           ContentAsUTF8 = "<h3>Hello from HttpServer :)</h3>",
                           StatusCode = ResponceStatusCode.OK
                       };
                   }
               }
            };

            HttpServer.HttpServer httpServer = new HttpServer.HttpServer(8081, routes);
            httpServer.Listen();
        }
    }
}
