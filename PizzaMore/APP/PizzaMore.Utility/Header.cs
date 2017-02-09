
//13.Implementing a Header class
namespace PizzaMore.Utility
{
    using System.Text;
    using PizzaMore.Utility.Interfaces;
    using System;

    public class Header
    {

        public Header()
        {
            this.Type = "Content-type: text/html";
            this.Cookies = new CookieCollection();
        }

        public string Type { get; set; }

        public string Location { get; set; }

        public ICookieCollection Cookies { get; private set; }

        public void AddLocation(string location)
        {
            this.Location = $"Location:{location}";
        }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.Append(this.Type);
            stringBuilder.Append(Environment.NewLine);

            if (this.Cookies.Count>0)
            {
                foreach (Cookie cookie in this.Cookies)
                {
                    stringBuilder.Append($"Set-Cookie: {cookie.ToString()}");
                    stringBuilder.Append(Environment.NewLine);
                }
            }

            if (this.Location!=null)
            {
                stringBuilder.Append(this.Location);
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }

    }
}
