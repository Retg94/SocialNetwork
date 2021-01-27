using SocialNetworkLibrary.Dtos.Users;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Users
{
    public class DictionaryUserRepository : IUserRepository
    {
        public Dictionary<int, User> _users = new Dictionary<int, User>();

        public DictionaryUserRepository()
        {
            var user1 = new User
            {
                UserId = 1,
                UserName = "Testa",
                Password = "BadPassword",
                EmailAdress = "test@mail.com"
            };
            var user2 = new User
            {
                UserId = 2,
                UserName = "FooBar",
                Password = "EvenWorsePassword",
                EmailAdress = "foobar@mail.com"
            };
            _users.Add(1, user1);
            _users.Add(2, user2);
        }
        public User GetUser(int id)
        {
            try
            {
                return _users[id];
            }
            catch(KeyNotFoundException)
            {
                throw new UserNotFound();
            }
        }
        public bool UserNameIsUnique(string username)
        {
            return _users.Any(e => String.Equals(e.Value.UserName, username, StringComparison.CurrentCultureIgnoreCase));
        }
        public int ValidateUniqueId(int id)
        {
            bool isOkay = false;
            while(!isOkay)
            {
                isOkay = true;
                if (_users.Any(e => e.Value.UserId == id))
                {
                    id += 1;
                    isOkay = false;
                }
            }
            return id;
        }

        public void AddUser(UserDto userDto)
        {
            var id = _users.Count + 1;
            id = ValidateUniqueId(id);
            var user = new User(id, userDto.UserName, userDto.Password, userDto.EmailAdress);
            bool usernameOkay = UserValidation.ValidateUsername(userDto.UserName);
            if(!usernameOkay)
            {
                throw new InvalidCharacters();
            }
            if (UserNameIsUnique(user.UserName))
            {
                throw new NonUniqueUserName();
            }
            if (_users.ContainsKey(user.UserId))
            {
                throw new NonUniqueId();
            }
            _users.Add(id, user);
        }

        public void DeleteUser(int userId)
        {
             _users.Remove(userId);      
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            foreach(var user in _users)
            {
                users.Add(user.Value);
            }
            return users;
        }
    }
}
