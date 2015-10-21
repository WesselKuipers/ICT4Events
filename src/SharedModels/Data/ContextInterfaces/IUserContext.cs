using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IUserContext : IRepositoryContext<User, int>
    {
    }
}
