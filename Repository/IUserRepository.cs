namespace Repository
{
    using Entities;

    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User?> GetUsers(string userName, string code);
        Task UpdateUser(int id, User updatedUser);
    }
}