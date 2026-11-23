using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
       
        Task<User> GetUserById(int id);
        Task<User> UpdateUserById(int id, User user);
        Task<User> FindUserByNameAndPassword(Userin userin);
    }
}