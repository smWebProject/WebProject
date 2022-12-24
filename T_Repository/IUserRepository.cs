namespace T_Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User?> GetUsers(string userName, string code);
        void UpdateUser(int id, User updatedUser);
    }
}