using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UI.Helpers
{
    internal static class HashHelper
    {
        public static string Hash(string text)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] buffer = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha256.ComputeHash(buffer);

            string hashString = Convert.ToBase64String(hash);
            return hashString;
        }
    }
}
