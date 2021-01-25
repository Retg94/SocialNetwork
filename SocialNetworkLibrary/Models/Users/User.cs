using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkLibrary.Models.Users
{
    public class User
    {
        private const string _stringMessage = "{0} must be between {2} and {1} characters long";
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

        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }

    }
}
