using Newtonsoft.Json;
using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Models.Users;
using SocialNetworkLibrary.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;
using static SocialNetworkLibrary.Repositories.Posts.PostExceptions;

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
                UserId = user1.UserId,
            };
            var user2 = dictionaryUserRepository.GetUser(2);
            var post2 = new Post(2)
            {
                Content = "It's my birthday",
                UserId = user2.UserId,
            };
            _posts.Add(1, post1);
            _posts.Add(2, post2);
        }
        public Post GetPostById(int id)
        {
            return _posts[id];
        }

        public List<Post> GetAllPosts()
        {
            /*string posts = string.Empty;
            foreach(var post in _posts)
            {
                posts += JsonConvert.SerializeObject(post.Value, Formatting.Indented);
            }
            return posts;*/
            var posts = new List<Post>();
            foreach(var post in _posts)
            {
                posts.Add(post.Value);
            }
            return posts;
        }
        public void AddPost(PostDto postDto)
        {
            var id = _posts.Count + 1;
            var post = new Post(id, postDto);
            _posts.Add(id, post);
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
        public Post UpdateContent(int postId, PostDto postDto)
        {
            if (!CorrectUser(postId, postDto.UserId))
            {
                throw new NotCorrectUser();
            }
            var post = GetPostById(postId);
            post.Content = postDto.Content;
            post.LastDate = DateTime.Now;
            return post;
        }

        public bool CorrectUser(int postId, int userId)
        {
            Post post = GetPostById(postId);
            User user = _userRepository.GetUser(userId);
            if (post.UserId == user.UserId)
            {
                return true;
            }
            else
                return false;
        }
        public void DeletePost(int postId, int userId)
        {

            if (!CorrectUser(postId, userId))
            {
                throw new NotCorrectUser();
            }
            _posts.Remove(postId);
        }      
    }
}

