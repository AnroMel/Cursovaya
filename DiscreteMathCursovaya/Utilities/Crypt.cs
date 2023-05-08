using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DiscreteMathCursovaya
{
    public static class Crypt
    {
        public static string GetHashPassword(string password)
        {
            using var crypt = SHA256.Create();
            var hash = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hashString = new StringBuilder();
            foreach (var x in hash)
                hashString.Append(x.ToString("x2"));

            return hashString.ToString();
        }
    }
}
