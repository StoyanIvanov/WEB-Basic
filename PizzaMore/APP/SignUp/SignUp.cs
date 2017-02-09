using System;
using System.Collections.Generic;
using System.Web;
using PizzaMore.Data;
using PizzaMore.Models;
using PizzaMore.Utility;

namespace SignUp
{
    public class SignUp
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;

        static void Main()
        {

            if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                string userName = HttpUtility.UrlDecode(RequestParameters["email"]);
                string password = HttpUtility.UrlDecode(PasswordHeader.Hash(RequestParameters["password"]));

                if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(password))
                {
                    if (!DataBridge.IsUserExist(userName, password))
                    {
                        DataBridge.CreateUser(userName, password);
                    }

                }
            }

            ShowPage();
        }


        private static void ShowPage()
        {


            Header.Print();
            Logger.Log($"{"asdasdasd"} : {"asdasdasd"}");
            WebUtil.PrintFileContent("../../htdocs/signUp-EN.html");

        }

    }
}
