using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace L0_Core.Helper
{
    public class Md5Helper
    {
        public string GetMd5(string text)
        {
            string res = "";
            byte[] result = Encoding.Default.GetBytes(text); 
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            res = BitConverter.ToString(output).Replace("-", "");

            return res;
        }
    }
}
