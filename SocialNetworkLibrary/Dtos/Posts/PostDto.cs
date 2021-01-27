using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkLibrary.Dtos.Posts
{
    public class PostDto
    {
        private const string _stringMessage = "{0} must be between {2} and {1} characters long";

        /// <summary>
        /// The content of the user
        /// </summary>
        /// <example>My exam is tomorrow. I am so nervous.</example>>
        [Required]
        [StringLength(400, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Content { get; set; }

        /// <summary>
        /// The id of the user who wrote the post
        /// </summary>
        [Required]
        public int UserId { get; set; }
    }
}
