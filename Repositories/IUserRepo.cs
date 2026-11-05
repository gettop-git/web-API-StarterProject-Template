using Entities;

namespace Repositories
{
    public interface IUserRepo
    {
        User AddUser(User user);
        User GetUserById(int id);
        User? UpdateUserById(int id, User user);
        User UserLogIn(Userin userin);
    }
}