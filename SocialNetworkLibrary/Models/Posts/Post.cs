using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Models.Posts
{
    public class Post
    {
        public Post(int id)
        {
            Id = id;
        }
        public Post(int id, PostDto postDto, User user)
        {
            Id = id;
            Content = postDto.Content;
            LastDate = postDto.LastDate;
            CreatedBy = user;
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime LastDate { get; set; }
        public User CreatedBy { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public List<User> Likes { get; set; } = new List<User>();
    }
}
