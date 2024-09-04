using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
namespace FashionWebsite.Models
{
    public class MaHoa
    {
        public static String encryptSHA256(string PlainText)
        {
            string result = "";
            //Tạo 1 SHA256 object
            using (SHA256 bb = SHA256.Create())
            {
                byte[] sourceData = Encoding.UTF8.GetBytes(PlainText);
                byte[] hashResult = bb.ComputeHash(sourceData);
                result = BitConverter.ToString(hashResult);
            }
            return result;
        }

    }
}