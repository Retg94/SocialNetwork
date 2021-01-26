using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkLibrary.Dtos.Users
{
    public class UserDto
    {
        private const string _stringMessage = "{0} must be between {2} and {1} characters long";
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
