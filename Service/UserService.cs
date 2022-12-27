namespace Service
{
    using T_Repository;
    using Entities;
    using System;
    using System.Text.Json;

    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;
        public UserService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        

        public async Task<User?> GetUsers(string userName, string code)
        {
                var user=await _iUserRepository.GetUsers(userName, code);
                if (user != null)
                    return user;
                return null;
        }
        public async Task<User> AddUser(User user)
        {

            User resUser = await _iUserRepository.AddUser(user);
            if (resUser != null)
                return resUser;
            return null;

        }
        public void UpdateUser(int id, User updatedUser)
        {
            _iUserRepository.UpdateUser(id, updatedUser);
        }



    }
}