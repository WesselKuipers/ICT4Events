using System;
using System.Net.Mail;
using System.Text;
using SharedModels.Models;
using System.Security.Cryptography;
using SharedModels.Data.OracleContexts;
using SharedModels.Enums;

namespace SharedModels.Logic
{
    public class UserLogic
    {
        // TODO: check for permissionTypes in methods
        
        private readonly UserOracleContext _context;
        private static readonly string Salt = GetHashString("saltyString");

        public UserLogic()
        {
            _context = new UserOracleContext();
        }

        /// <summary>
        /// Sets the password for a user if the 2 given passwords match.
        /// </summary>
        /// <param name="user">user to set password for</param>
        /// <param name="password">password given by user</param>
        /// <param name="passwordAgain">password again given by user</param>
        public void SetPassword(User user, string password, string passwordAgain)
        {
            if (string.Equals(password, passwordAgain))
                user.Password = GetHashString(password + Salt);
            else
                throw new PasswordsDontMatchException();
        }

        /// <summary>
        /// Registers a new user and sends a confirmation email to the new users emailaddress
        /// </summary>
        /// <param name="user">User created in user interface</param>
        /// <returns>a new user object with correct user id</returns>
        public User RegisterUser(User user)
        {
            var registeredUser = _context.Insert(user);
            SendConfirmationEmail(registeredUser);
            return registeredUser;
        }

        /// <summary>
        /// Sends a confirmation email to given user
        /// </summary>
        /// <param name="user">user to send confirmation email to</param>
        /// <returns>true if mail was successfully send, throws exception if sending mail fails</returns>
        private static bool SendConfirmationEmail(User user)
        {
            // TODO: Create a new email account for ICT4Events
            var message = new MailMessage("ICT4EventsEmail@test.com", user.Username)
            {
                Subject = "Confirmation of your new user account for ICT4Events",
                Body =
                    "Hello " + user.Name + ",\r\n\r\n" +
                    "Your new account for ICT4Events was successfully created!\r\n\r\n" + 
                    "Have a nice day!"
            };

            // TODO: Find out what our smtp host is
            var smtp = new SmtpClient("Wat is onze smtp host?");

            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Changes the user accounts permission level
        /// </summary>
        /// <param name="user">user to change permission level of</param>
        /// <param name="newPermissionType">PermissionType to change permission level to</param>
        public void ChangePermissionType(User user, PermissionType newPermissionType) => user.Permission = newPermissionType;


        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user">User to be updated</param>
        /// <returns>Updated user</returns>
        public bool UpdateUser(User user) => _context.Update(user);

        /// <summary>
        /// Deletes a user account with given user id
        /// </summary>
        /// <param name="userId">ID of the user to be deleted</param>
        /// <returns>true if delete was succesfull</returns>
        public bool DeleteUserById(int userId) => _context.Delete(_context.GetById(userId));

        /// <summary>
        /// Deletes a user account with given user
        /// </summary>
        /// <param name="user">user to be deleted</param>
        /// <returns>true if delete was succesfull</returns>
        public bool DeleteUser(User user) => _context.Delete(user);

        /// <summary>
        /// Hashes the given string in SHA1 format.
        /// </summary>
        /// <param name="inputString">string to hash</param>
        /// <returns>an array of bytes</returns>
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// returns a hashed string in SHA1 format;
        /// </summary>
        /// <param name="inputString">string to hash</param>
        /// <returns></returns>
        private static string GetHashString(string inputString)
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
