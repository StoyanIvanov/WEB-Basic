namespace HttpServer.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class CookieCollection : IEnumerable<Cookie>
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public IDictionary<string, Cookie> Cookies
        {
            get;
            private set;
        }

        public int Count
        {
            get { return this.Cookies.Count; }
        }

        public bool Contains(string cookieName)
        {
            if (this.Cookies.Keys.Contains(cookieName))
            {
                return true;
            }

            return false;
        }

        public void Add(Cookie cookie)
        {
            if (this.Cookies.ContainsKey(cookie.Name))
            {
                this.Cookies[cookie.Name].Value = cookie.Value;
            }
            else
            {
                this.Cookies.Add(cookie.Name, cookie);
            }
        }

        public Cookie this[string cookieName] {
            get
            {
                if (this.Cookies.Keys.Contains(cookieName))
                {
                    return this.Cookies[cookieName];
                }

                return null;
            }
            set
            {
                if (this.Cookies.ContainsKey(cookieName))
                {
                    this.Cookies[cookieName] = value;
                }
                else
                {
                    this.Cookies.Add(cookieName, value);
                }
            }
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join("; ", this.Cookies.Values);
        }
    }
}
