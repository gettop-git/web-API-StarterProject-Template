using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UserService : IUserService

    {
        IUserRepo repo;
        public UserService(IUserRepo repository)
        {
            this.repo = repository;
        }
        public User GetUserById(int id)
        {
            User user = repo.GetUserById(id);
            return user;
        }
        public User AddUser(User user)
        {
            User useri = repo.AddUser(user);
            return useri;

        }
        public User UserLogIn(Userin userin)
        {
            User user = repo.UserLogIn(userin);
            return user;
        }
        public User UpdateUserById(int id, User user)
        {
            User userI = repo.UpdateUserById(id, user);
            return userI;
        }
        public int CheckPassword(string password)
        {
            var res = Zxcvbn.Core.EvaluatePassword(password);
            return res.Score;
        }
    }
}
