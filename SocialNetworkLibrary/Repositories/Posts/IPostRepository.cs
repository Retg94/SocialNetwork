using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Posts
{
    public interface IPostRepository
    {
        Post AddPost(PostDto postDto);
        void DeletePost(int postId);
        string GetAllPosts();
        Post GetPostById(int id);
        Post LikeOrUnlikePost(int postId, int userId);
        Post UpdateContent(int postId, string content);
    }
}
