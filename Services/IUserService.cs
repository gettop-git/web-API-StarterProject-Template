using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        int CheckPassword(string password);
        Task<User> GetUserById(int id);
        Task<User> UpdateUserById(int id, User user);
        Task<User> UserLogIn(Userin userin);
    }
}