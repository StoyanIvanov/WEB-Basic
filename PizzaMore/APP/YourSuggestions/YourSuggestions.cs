using System;
using System.Collections.Generic;
using PizzaMore.Data;
using PizzaMore.Models;
using PizzaMore.Utility;

namespace YourSuggestions
{
    public class YourSuggestions
    {
        private static IDictionary<string, string> PostParams;
        private static Session Session;
        private static Header Header = new Header();

        static void Main()
        {
            Session = WebUtil.GetSession();
            if (Session == null)
            {
                Header.Print();
                WebUtil.PageNotAllowed();
                return;
            }

            if (WebUtil.isGet())
            {
                ShowPage();
            }
            else if (WebUtil.IsPost())
            {
                DeletePizza();
                ShowPage();
            }

        }

        private static void DeletePizza()
        {
            PostParams = WebUtil.RetrievePostParameters();
            DataBridge.DeletePizzaById(int.Parse(PostParams["pizzaId"]));
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../../htdocs/yoursuggestions-top.html");
            PrintListOfSuggestedItems();
            WebUtil.PrintFileContent("../../htdocs/yoursuggestions-bottom.html");
        }

        private static void PrintListOfSuggestedItems()
        {
            var suggestions = DataBridge.GetPizzasByOwnerId(Session.UserId);
            Console.WriteLine("<ul>");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }

            Console.WriteLine("</ul>");
        }
    }
}
