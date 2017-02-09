using System.Collections;
using System.Collections.Generic;

namespace PizzaMore.Utility.Interfaces
{
    public interface ICookieCollection: IEnumerable<Cookie>
    {
        void AddCookie(Cookie cookie);
        void RemoveCookie(string cookieName);
        bool ConstainsKey(string key);
        int Count { get; }
        Cookie this[string key] { get; set; }
    }
}