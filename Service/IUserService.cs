using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User?> GetUsers(string userName, string code);
        Task UpdateUser(int id, User updatedUser);
    }
}