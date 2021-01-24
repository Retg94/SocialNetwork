using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Models.Users
{
    public class User
    {
        public User(int id, string username, string password, string emailadress)
        {
            Id = id;
            UserName = username;
            Password = password;
            EmailAdress = emailadress;
        }
        public User()
        {

        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }

    }
}
