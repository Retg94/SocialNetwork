using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Dtos.Posts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime LastDate { get; set; }
        public User CreatedBy { get; set; }
    }
}
