using SocialNetworkLibrary.Dtos.Users;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Users
{
    public interface IUserRepository
    {
        User AddUser(UserDto user);
        User GetUser(int id);
    }
}
