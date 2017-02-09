using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using PizzaMore.Data;
using PizzaMore.Models;
using PizzaMore.Utility.Interfaces;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            var environmentVariable = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            if (environmentVariable != null && environmentVariable.ToUpper()=="POST")
            {
                return true;
            }

            return false;
        }

        public static bool isGet()
        {
            var environmentVariable = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            if (environmentVariable != null && environmentVariable.ToUpper() == "GET")
            {
                return true;
            }

            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {

            return RetrieveRequestParameters(Environment.GetEnvironmentVariable("QUERY_STRING"));
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            return RetrieveRequestParameters(Console.ReadLine());
        }

        public static IDictionary<string, string> RetrieveGetParameters(string queryString)
        {

            return RetrieveRequestParameters(queryString);
        }

        public static IDictionary<string, string> RetrievePostParameters(string parameterString)
        {
            return RetrieveRequestParameters(parameterString);
        }

        public static IDictionary<string, string> RetrieveRequestParameters(string queryString)
        {
            Logger.Log(queryString);
            IDictionary<string, string> getParameters = new Dictionary<string, string>();

            if (queryString != null)
            {
                string[] splitQueryString = queryString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var queryParameter in splitQueryString)
                {
                    string[] parameter = queryParameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string parameterName = HttpUtility.UrlDecode(parameter[0]);
                    string parameterValue = HttpUtility.UrlDecode(parameter[1]);

                    getParameters.Add(parameterName, parameterValue);

                }
            }

            return getParameters;
        }

        public static ICookieCollection GetCookies()
        {

            var httpCookie = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            ICookieCollection cookieCollection=new CookieCollection();
            if (httpCookie!=null)
            {
                var cookies = httpCookie.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var cookie in cookies)
                {
                    string[] parameters = cookie.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    Cookie newCookie = new Cookie(parameters[0], parameters[1]);
                    cookieCollection.AddCookie(newCookie);
                }
            }
 
            return cookieCollection;
        }

        public static Session GetSession()
        {
            ICookieCollection cookieCollection = GetCookies();

            if (!cookieCollection.ConstainsKey("sid"))
            {
                return null;
            }

            return DataBridge.GetSessionById(cookieCollection["sid"].Value);
        }

        public static void PrintFileContent(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine(File.ReadAllText(path));
            }
        }

        //  "../../htdocs/pa/game/index.html"
        public static void PageNotAllowed()
        {
            var filePathNotAllowed = @"../../htdocs/game/index.html";
            PrintFileContent(filePathNotAllowed);
        }
    }
}
