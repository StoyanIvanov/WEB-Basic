using HttpServer.Enums;

namespace HttpServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Header
    {
        public Header(HeaderType headerType)
        {
            this.HeaderType = headerType;
            this.ContentType = "text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public HeaderType HeaderType { get; set; }
        public string ContentType { get; set; }
        public string ContentLength { get; set; }
        public Dictionary<string, string> OtherParameters { get; set; }
        public CookieCollection Cookies { get; private set; }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.Add(cookie);
        }
        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine($"Content-Type: {this.ContentType}");
            if (!String.IsNullOrEmpty(this.ContentLength))
            {
                header.AppendLine($"Content-Length: {this.ContentLength}");
            }
            if (this.Cookies.Count>0)
            {
                if (this.HeaderType==HeaderType.HttpRequest)
                {
                    header.AppendLine($"Cookie: {this.Cookies.ToString()}");
                } else if (this.HeaderType == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine($"Set-Cookie: {cookie}");
                    }
                }
            }
            
            foreach (var otherParameter in this.OtherParameters)
            {
                header.AppendLine($"{otherParameter}: {otherParameter.Value}");
            }
            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}
