using System;
using System.Security.Cryptography;
using System.Text;

namespace HyperGnosys.Core
{
    public static class StringTransformer
    {
        public static string Normalize(this string text)
        {
            text = text.ToLower();
            text = text.Replace(" ", "");
            return text;
        }
        public static Guid ToGuid(this string id)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] inputBytes = Encoding.Default.GetBytes(id);
            byte[] hashBytes = provider.ComputeHash(inputBytes);
            return new Guid(hashBytes);
        }
    }
}