using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace VetClinic.Infrastructure
{
    public static class PasswordHasher
    {
        public static string GetHashPassword(string pass)
        { 
            byte[] bytes = Encoding.Unicode.GetBytes(pass);

            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();
            
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;
 
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}