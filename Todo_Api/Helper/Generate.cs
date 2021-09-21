using System;
using System.Linq;

namespace Todo_Api.Helper
{
    public static class Generate
    {
        private static Random random = new Random();

        public static string Key()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}