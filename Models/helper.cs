using EntityV2.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http.Headers;

namespace EntityV2.Models
{
    public static class helper
    {
        public static bool checkToken(CookieHeaderValue cookie)
        {
            if (cookie == null)
            {
                return false;
            }
            string guid = cookie.Cookies.First().Value;
            using (DataBase db = DataBase.Create())
            {
                Token token = db.Tokens.Where(x => x.Guid == guid).FirstOrDefault();

                if (token != null && DateTime.Now < token.Expire)
                {
                    return true;
                }
                return false;
            }
        }

        public static string EncodePassword(string pass_original)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(pass_original);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string DecodePassword(string pass_codificada)
        {
            var base64EncodedBytes = Convert.FromBase64String(pass_codificada);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }



    }
}
