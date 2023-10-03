using Bondlog.Shared.Domain.Models;
using System.Security.Cryptography;

namespace Bondlog.Shared.Helpers
{
    public class UserPasswordValidation
    {

        //bool DoPasswordMatch = VerifyUserPassword(loginModel.Password!, user.Password!);
        //    if(!DoPasswordMatch)
        //        return new UserSession();

        public static bool VerifyUserPassword(string rawPassword, string databasePassword)
        {
            byte[] dbPasswordHash = Convert.FromBase64String(databasePassword);
            byte[] salt = new byte[16];

            Array.Copy(dbPasswordHash, 0, salt, 0, 16);

            var rfcPassword = new Rfc2898DeriveBytes(rawPassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);

            for (int i = 0; i < rfcPasswordHash.Length; i++)
            {
                if (dbPasswordHash[i + 16] != rfcPasswordHash[i])
                    return false;
            }

            return true;
        }
    }
}
