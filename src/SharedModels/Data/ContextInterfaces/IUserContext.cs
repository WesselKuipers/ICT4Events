using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IUserContext
    {
        List<User> GetAll();
        User GetById(int id);
        User Insert(User user);
        bool Update(User user);
        bool Delete(User user);
    }
}
