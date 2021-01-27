using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkLibrary.Dtos.Users
{
    public class UserDto
    {
        private const string _stringMessage = "{0} must be between {2} and {1} characters long";

        /// <summary>
        /// The username of the user. Can only contain between 5 and 100 characters and can only contain alphanumeric characters.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string UserName { get; set; }

        /// <summary>
        /// The password of the user. Can only contain between 5 and 100 characters
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Password { get; set; }

        /// <summary>
        /// The emailadress of the user. Can only contain between 5 and 100 characters
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = _stringMessage, MinimumLength = 5)]
        [EmailAddress]
        public string EmailAdress { get; set; }
    }
}
