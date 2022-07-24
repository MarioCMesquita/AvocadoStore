﻿using System.Security.Cryptography;
using System.Text;

namespace AvocadoStore_API.Utils
{
    public class Utilities
    {
        public string GenerateHash(string login, string password)
        {
            var result = "";

            string concatPass = password + login;
            var passwordBytes = Encoding.UTF8.GetBytes(concatPass);

            using (SHA512 sha = new SHA512Managed())
            {
                var resultBytes = sha.ComputeHash(passwordBytes);

                var hashedBuilder = new StringBuilder(128);
                foreach (var item in resultBytes)
                {
                    hashedBuilder.Append(item.ToString("X2"));
                }

                result = hashedBuilder.ToString();
            }

            return result;
        }
    }
}
