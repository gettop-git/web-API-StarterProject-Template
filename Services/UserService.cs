using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UserService : IUserService

    {
        IUserRepository repo;
        public UserService(IUserRepository repository)
        {
            this.repo = repository;
        }
        public async Task<User> GetUserById(int id)
        {
            User user = await repo.GetUserById(id);
            return user;
        }
        public async Task<User> AddUser(User user)
        {
            User useri = await repo.AddUser(user);
            return useri;

        }
        public async Task<User> UserLogIn(Userin userin)
        {
            User user = await repo.FindUserByNameAndPassword(userin);
            return user;
        }
        public async Task<User> UpdateUserById(int id, User user)
        {
            User userI = await repo.UpdateUserById(id, user);
            return userI;
        }
        public int CheckPassword(string password)
        {
            var res = Zxcvbn.Core.EvaluatePassword(password);
            return res.Score;
        }
    }
}
