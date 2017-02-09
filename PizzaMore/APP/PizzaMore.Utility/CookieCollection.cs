
using System.Collections;

namespace PizzaMore.Utility
{
    using System.Collections.Generic;
    using System.Data;
    using PizzaMore.Utility.Interfaces;

    public class CookieCollection : ICookieCollection
    {
        private Dictionary<string, Cookie> cookies;
        private int count;

        public CookieCollection()
        {
            this.cookies=new Dictionary<string, Cookie>();
            this.count = 0;
        }

        public void AddCookie(Cookie cookie)
        {
            if (this.cookies.ContainsKey(cookie.Name))
            {
                throw new DuplicateNameException();
            }
            else
            {
                this.cookies.Add(cookie.Name,cookie);
                this.count++;
            }
        }

        public void RemoveCookie(string cookieName)
        {
            if (this.cookies.ContainsKey(cookieName))
            {
                this.cookies.Remove(cookieName);
                this.count--;
            }
        }

        public bool ConstainsKey(string key)
        {
            if (this.cookies.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public int Count => this.count;

        public Cookie this[string key]
        {
            get { return this.cookies[key]; }
            set { this.cookies[key] = this[key]; }
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }
    }
}
