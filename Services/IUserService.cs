using Entities;

namespace Services
{
    public interface IUserService
    {
        User AddUser(User user);
        int CheckPassword(string password);
        User GetUserById(int id);
        User UpdateUserById(int id, User user);
        User UserLogIn(Userin userin);
    }
}