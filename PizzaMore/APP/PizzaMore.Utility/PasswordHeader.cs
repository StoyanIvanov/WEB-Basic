using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PizzaMore.Utility
{
    public static class PasswordHeader
    {
        public static string Hash(string password)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}
