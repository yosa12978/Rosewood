using Rosewood.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Rosewood.Services.Impls;

public class MD5Service : IPasswordService
{
    public string HashPassword(string password)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
