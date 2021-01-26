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
        public Post(int id)
        {
            PostId = id;
            CreatedDate = DateTime.Now;
        }
        public Post(int id, PostDto postDto, IUserRepository _userRepository)
        {
            PostId = id;
            Content = postDto.Content;
            CreatedDate = DateTime.Now;
            UserId = postDto.UserId;
        }
        public int PostId { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = _stringMessage, MinimumLength = 5)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public List<User> Likes { get; set; } = new List<User>();
    }
}
