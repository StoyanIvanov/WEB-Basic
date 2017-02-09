using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Models;
using PizzaMore.Utility;

namespace SignIn
{
    public class SignIn
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header = new Header();

        static void Main()
        {
            if (WebUtil.IsPost())
            {
                LogIn();
            }

            ShowPage();


        }

        private static void LogIn()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            string email = RequestParameters["email"];
            string password = RequestParameters["password"];
            string hashedPassword = PasswordHeader.Hash(RequestParameters["password"]);
            var user = DataBridge.LogInUser(email, password);

            if (user!=null)
            {
                var session = new Session()
                {
                    Id = new Random().Next().ToString(),
                    User = user

                };

                Header.AddCookie(new Cookie("sid", session.Id));
                DataBridge.AddSession(session);
                DataBridge.SaveChanges();

            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../../htdocs/signin.html");
        }
    }
}
