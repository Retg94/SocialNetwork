using SocialNetworkLibrary.Dtos.Users;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Users
{
    public class DictionaryUserRepository : IUserRepository
    {
        private Dictionary<int, User> _users = new Dictionary<int, User>();

        public DictionaryUserRepository()
        {
            var user1 = new User
            {
                Id = 1,
                UserName = "Test",
                Password = "BadPassword",
                EmailAdress = "test@mail.com"
            };
            var user2 = new User
            {
                Id = 2,
                UserName = "FooBar",
                Password = "EvenWorsePassword",
                EmailAdress = "foobar@mail.com"
            };
            _users.Add(1, user1);
            _users.Add(2, user2);
        }
        public User GetUser(int id)
        {
            return _users[id];
        }
        public User AddUser(UserDto userDto)
        {
            var id = _users.Count + 1;
            var user = new User(id, userDto.UserName, userDto.Password, userDto.EmailAdress);
            _users.Add(id, user);
            return user;
        }
        public void DeleteUser(int userId)
        {
             _users.Remove(userId);      
        }
    }
}
