using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;
using System.Security.Cryptography;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Enums;

namespace SharedModels.Logic
{
    public class UserLogic
    {
        // TODO: check for permissionTypes in methods

        //private readonly User _user;
        private IUserContext _context;

        public static string Salt = GetHashString("saltyString");

        //public UserLogic(User user)
        //{
        //    _user = user;
        //}

        public UserLogic(IUserContext context)
        {
            _context = context;
        }

        // TODO: Move this method to UI logic? Or: Pass user object
        /// <summary>
        /// Sets the password for a user if the 2 given passwords match.
        /// </summary>
        /// <param name="password">password given by user</param>
        /// <param name="passwordAgain">password again given by user</param>
        public void SetPassword(string password, string passwordAgain)
        {
            //if (string.Equals(password, passwordAgain))
            //    _user.Password = GetHashString(password + Salt);
            //else
            //    throw new PasswordsDontMatchException();
        }

        /// <summary>
        /// Gets a hashed password.
        /// </summary>
        /// <param name="password">password to hash</param>
        public static string GetHashedPassword(string password)
        {
            return GetHashString(password + Salt);
        }

        /// <summary>
        /// Registers a new user, sends a confirmation email to the new users emailaddress
        /// </summary>
        /// <param name="user">User created in user interface</param>
        /// <returns>a new user object with correct user id</returns>
        public User RegisterUser(User user)
        {
            // TODO: use UserOracleContext.Insert(user) as return value
            // TODO: send confirmation email

            return user;
        }

        /// <summary>
        /// Changes the user accounts permission level
        /// </summary>
        /// <param name="newPermissionType">PermissionType to change permission level to</param>
        public void ChangePermissionType(PermissionType newPermissionType)
        {
            //_user.Permission = newPermissionType;
        }


        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user">User to be updated</param>
        /// <returns>Updated user</returns>
        public User UpdateUser(User user)
        {
            // TODO: return UserOracleContext.Update(user);
            return user;
        }

        /// <summary>
        /// Deletes a user account
        /// </summary>
        /// <param name="userId">ID of the user to be deleted</param>
        /// <returns>true if delete was succesfull</returns>
        public bool DeleteUser(int userId)
        {
            // TODO: return UserOracleContext.Delete(userId);
            return true;
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
