using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Models.Likes
{
    public class Likes
    {
        public Likes()
        {

        }
        public Likes(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
