using Newtonsoft.Json;
using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Models.Users;
using SocialNetworkLibrary.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Posts
{
    public class DictionaryPostRepository : IPostRepository
    {
        private readonly IUserRepository _userRepository = new DictionaryUserRepository();
        private readonly Dictionary<int, Post> _posts = new Dictionary<int, Post>();

        public DictionaryPostRepository(IUserRepository dictionaryUserRepository)
        {
            var user1 = dictionaryUserRepository.GetUser(1);
            var post1 = new Post(1)
            {
                Content = "I like food",
                LastDate = new DateTime(2000,1,1),
                CreatedBy = user1,
            };
            var user2 = dictionaryUserRepository.GetUser(2);
            var post2 = new Post(2)
            {
                Content = "It's my birthday",
                LastDate = new DateTime(1994, 3, 13),
                CreatedBy = user2,
            };
            _posts.Add(1, post1);
            _posts.Add(2, post2);
        }
        public Post GetPostById(int id)
        {
            return _posts[id];
        }

        public string GetAllPosts()
        {
            string posts = string.Empty;
            foreach(var post in _posts)
            {
                posts += JsonConvert.SerializeObject(post.Value, Formatting.Indented);
            }
            return posts;
        }
        public Post AddPost(PostDto postDto)
        {
            var id = _posts.Count + 1;
            var post = new Post(id, postDto, _userRepository);
            _posts.Add(id, post);
            return post;
        }
        public Post LikeOrUnlikePost(int postId, int userId)
        {
            Post post = GetPostById(postId);
            User user = _userRepository.GetUser(userId);
            if(!post.Likes.Contains(user))
            {
                post.Likes.Add(user);
            }
            else
            {
                post.Likes.Remove(user);
            }
            return post;
        }
        public Post UpdateContent(int postId, string newContent)
        {
            var post = GetPostById(postId);
            post.Content = newContent;
            post.LastDate = DateTime.Now;
            return post;
        }
        public void DeletePost(int postId)
        {
            _posts.Remove(postId);
        }      
    }
}

