using System.Collections.Generic;
using PizzaMore.Models;
using PizzaMore.Utility;

namespace Home
{
    public class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;

        static void Main()
        {
            AddDefaultLanguageCookie();

            if (WebUtil.isGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                //TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                Logger.Log("Catch that the request is POST");
                RequestParameters = WebUtil.RetrievePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }

            ShowPage();
        }

        private static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ConstainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            
            if (Language.Equals("DE"))
            {
                Header.Print();
                ServeHtmlBg();
            }
            else if(Language.Equals("BG"))
            {
                Header.Print();
                ServeHtmlBg();
            } else if (Language.Equals("EN"))
            {
                Header.Print();
                ServeHtmlEn();
            }
        }

        private static void ServeHtmlDe()
        {
            WebUtil.PrintFileContent("../../htdocs/home-de.html");
        }

        private static void ServeHtmlBg()
        {
            WebUtil.PrintFileContent("../../htdocs/home.html");
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent("../../htdocs/home-EN.html");
        }
    }
}
