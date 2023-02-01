using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        WebSiteContext _context;
        public UserRepository(WebSiteContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUsers(string userName, string code)
        {
            var list = await (from u in _context.Users
                              where u.UserName == userName && u.Code == code
                              select u).ToListAsync();
            return list.FirstOrDefault();
        }
        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }
        public async Task UpdateUser(int id, User updatedUser)
        {
            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
