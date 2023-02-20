using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISMS_API.Helpers
{
    public static class CryptographyHelper
    {
        public static string GenerateHash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x3"));
            }
            return builder.ToString();
        }

    }
}
