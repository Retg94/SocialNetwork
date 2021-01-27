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
            UserId = id;
            UserName = username;
            Password = password;
            EmailAdress = emailadress;
        }
        public User()
        {

        }

        /// <summary>
        /// The id of the user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// UserName of the user. Can only contain between 5 and 100 characters and can only contain alphanumeric characters.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string UserName { get; set; }

        /// <summary>
        /// Password for the user. Can only contain between 5 and 100 characters
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Password { get; set; }

        /// <summary>
        /// The users emailadress. Can only contain between 5 and 100 characters
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        [EmailAddress]
        public string EmailAdress { get; set; }

    }
}
