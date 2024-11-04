using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bezbednost
{
    public class HashingHelper
    {
        public static string CreateHash(string password)
        {
            using (var hash = new HMACSHA512())
            {
              
                var hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes); 
            }
        }
        public static bool VerifyHash(string password, string passwordHash)
        {
            using (var hash = new HMACSHA512())
            {
                var hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes) == passwordHash;
            }
        }


    }
}
