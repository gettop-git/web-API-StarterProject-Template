using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        MyStorDBContext _context;
        public UserRepository(MyStorDBContext _context)
        {
            this._context = _context;
            
        }
        
    
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);

        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
            
        }
        public async Task<User> FindUserByNameAndPassword(Userin userin)
        {
            return await _context.Users.Where(user => user.Email == userin.Email && user.Password == userin.Password).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUserById(int id, User user)
        {
           user.Id = id;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
