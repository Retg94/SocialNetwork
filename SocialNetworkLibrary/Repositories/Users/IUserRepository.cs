using SocialNetworkLibrary.Dtos.Users;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Users
{
    public interface IUserRepository
    {
        void AddUser(UserDto user);
        void DeleteUser(int userId);
        List<User> GetAllUsers();
        User GetUser(int id);
        bool UserNameIsUnique(string username);
    }
}
