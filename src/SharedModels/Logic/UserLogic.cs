using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;
using System.Security.Cryptography;

namespace SharedModels.Logic
{
    public class UserLogic
    {
        private readonly User _user;
        public static string Salt = GetHashString("saltyString");

        public UserLogic(User user)
        {
            _user = user;
        }

        /// <summary>
        /// Sets the password for a user if the 2 given passwords match.
        /// </summary>
        /// <param name="password">password given by user</param>
        /// <param name="passwordAgain">password again given by user</param>
        public void SetPassword(string password, string passwordAgain)
        {
            if (string.Equals(password, passwordAgain))
                _user.Password = GetHashString(password + Salt);
            else
                throw new PasswordsDontMatchException();
        }

        /// <summary>
        /// Hashes the given string in SHA1 format.
        /// returns an array of bytes.
        /// </summary>
        /// <param name="inputString">string to hash</param>
        /// <returns></returns>
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// returns a hashed string in SHA1 format;
        /// </summary>
        /// <param name="inputString">string to hash</param>
        /// <returns></returns>
        public static string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (var b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }

    /// <summary>
    /// This exception should be thrown when 2 passwords do not match.
    /// </summary>
    internal class PasswordsDontMatchException : Exception
    {
        public override string Message => "Wachtwoorden komen niet overeen.";
    }
}
