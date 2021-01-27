using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Users;
using SocialNetworkLibrary.Repositories.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetworkLibrary.Models.Posts
{
    public class Post
    {
        private const string _stringMessage = "{0} must be between {2} and {1} characters long";
        public Post()
        {

        }
        public Post(int id)
        {
            PostId = id;
        }
        public Post(PostDto postDto)
        {
            Content = postDto.Content;
            UserId = postDto.UserId;
        }
        public Post(int id, PostDto postDto)
        {
            PostId = id;
            Content = postDto.Content;
            UserId = postDto.UserId;
        }

        /// <summary>
        /// The id of the the post
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// The content of the post. Must be between 5 and 400 characters.
        /// </summary>
        /// <example>My exam is tomorrow. I am so nervous.</example>>
        [Required]
        [StringLength(400, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Content { get; set; }

        /// <summary>
        /// The creation date and time of the post in the format YYYY-MM-DD HH:MM:SS
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date and time of the post if the post gets updated in the format YYYY-MM-DD HH:MM:SS
        /// </summary>
        public DateTime? LastDate { get; set; } = null;

        /// <summary>
        /// The userid of the user who created the post
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// A list containing the users that likes the post 
        /// </summary>
        public List<User> Likes { get; set; } = new List<User>();
    }
}
