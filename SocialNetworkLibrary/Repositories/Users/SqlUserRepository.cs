using Dapper;
using Microsoft.Data.Sqlite;
using SocialNetworkLibrary.Dtos.Users;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Users
{
    public class SqlUserRepository : IUserRepository
    {
        private const string _connectionString = "Data Source=.\\SocialNetwork.db";

        public void AddUser(UserDto userDto)
        {
            if (!UserNameIsUnique(userDto.UserName))
                throw new NonUniqueUserName();
            if (!UserValidation.ValidateUsername(userDto.UserName))
                throw new InvalidCharacters();
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = "INSERT INTO User (UserName, Password, EmailAdress)" + " VALUES(@UserName, @Password, @EmailAdress)";
                connection.Execute(sql, userDto);
            }
        }

        public void DeleteUser(int userId)
        {
            var user = GetUser(userId);
            using (var connection = new SqliteConnection(_connectionString))
            {
                var sql = $"DELETE FROM User WHERE UserId = @UserId";
                connection.Execute(sql, user);
            }
        }
        public List<User> GetAllUsers()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var users = connection.Query<User>("SELECT * FROM User");
                return users.ToList();
            }
        }
        public User GetUser(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var users = connection.Query<User>("SELECT * FROM User");
                users.ToList();
                if (!users.Any(e => e.UserId == id))
                    throw new UserNotFound();
                var user = new User();
                foreach(var person in users)
                {
                    if (person.UserId == id)
                        user = person;
                }
                return user;
            }
        }

        public bool UserNameIsUnique(string username)
        {
            bool isOkay = true;
            using (var connection = new SqliteConnection(_connectionString))
            {
                var users = connection.Query<User>("SELECT * FROM user");
                users = users.ToList();
                isOkay = !(users.Any(e => String.Equals(e.UserName, username, StringComparison.CurrentCultureIgnoreCase)));
            }
            return isOkay;
        }
    }
}
