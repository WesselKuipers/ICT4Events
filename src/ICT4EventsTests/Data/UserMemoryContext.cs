using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    class UserMemoryContext :  IUserContext
    {
        private List<User> _users = new List<User>();

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(object id)
        {
            return _users.FirstOrDefault(u => u.ID == (int) id);
        }

        public User Insert(User entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _users.Max(e => e.ID);
            var user = new User(id, entity.Username, entity.Password, entity.Name, entity.Surname, entity.Country,
                entity.City, entity.Postal, entity.Address, entity.Telephone, entity.RegistrationDate, entity.Permission);
            _users.Add(user);

            return user;
        }

        public bool Update(User entity)
        {
            var user = _users.FirstOrDefault(e => e.ID == entity.ID);
            if (user == null) return false;

            _users.Remove(user);
            _users.Add(entity);
            return true;
        }

        public bool Delete(User entity)
        {
            var user = _users.FirstOrDefault(e => e.ID == entity.ID);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }

        public User AuthenticateUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
