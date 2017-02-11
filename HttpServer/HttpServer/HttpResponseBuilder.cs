using System.IO;
using HttpServer.Enums;
using HttpServer.Models;

namespace HttpServer
{
    public static class HttpResponseBuilder
    {

        public static HttpResponse InternalServerError()
        {
            if (File.Exists(@"\Pages\500.html"))
            {
                  string content = System.IO.File.ReadAllText(@"\Pages\500.html");
            HttpResponse responce = new HttpResponse();
            return responce;
            }

            return null;
          
        }

        public static HttpResponse NotFound()
        {
            if (File.Exists(@"\Pages\404.html"))
            {
                string content = System.IO.File.ReadAllText(@"\Pages\404.html");
            HttpResponse responce = new HttpResponse();
            return responce;
            }

            return null;
        }
    }
}
