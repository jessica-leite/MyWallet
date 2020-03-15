using System.Security.Cryptography;
using System.Text;

namespace MyWallet.Web.Util
{
    public class CryptographyUtil
    {
        public static string Encrypt(string value)
        {
            var encodedValue = Encoding.UTF8.GetBytes(value);
            var encryptedPassword = SHA256.Create().ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}