using T_Repository;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User?> GetUsers(string userName, string code);
        void UpdateUser(int id, User updatedUser);
    }
}