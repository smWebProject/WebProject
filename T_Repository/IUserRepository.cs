namespace T_Repository
{
    using Entities;

    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User?> GetUsers(string userName, string code);
        void UpdateUser(int id, User updatedUser);
    }
}