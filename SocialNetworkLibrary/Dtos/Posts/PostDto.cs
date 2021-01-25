using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Dtos.Posts
{
    public class PostDto
    {
        public string Content { get; set; }
        public int CreatedBy { get; set; }
    }
}
