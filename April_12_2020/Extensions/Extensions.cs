using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace April_12_2020.Extensions
{
    static class Extensions
    {
        public static bool IsEmail(this string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string HashPassword(string password)
        {
            byte[] bytePassword = Encoding.ASCII.GetBytes(password);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hashBytePassword = md5.ComputeHash(bytePassword);

            return Encoding.ASCII.GetString(hashBytePassword);
        }
    }
}
