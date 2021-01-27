using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Models.Users;
using SocialNetworkLibrary.Repositories.Posts;
using SocialNetworkLibrary.Repositories.Users;

namespace SocialNetwork.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostsController(IPostRepository DictionaryPostRepository, IUserRepository DictionaryUserRepository)
        {
            _postRepository = DictionaryPostRepository;
            _userRepository = DictionaryUserRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Post> GetPost(int id)
        {
            var post = _postRepository.GetPostById(id);
            if (post is null)
                return NotFound(post);
            return post;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            var posts = _postRepository.GetAllPosts();
            if (posts is null)
                return NotFound(posts);
            return posts;
        }


        [HttpPost]
        [Route("addpost")]
        public ActionResult<Post> AddPost([FromBody] PostDto postDto)
        {

            var user = _userRepository.GetUser(postDto.UserId);
            if (user is null)
                return NotFound(user);
            _postRepository.AddPost(postDto);
            return NoContent();

        }

        [HttpPatch]
        [Route("{postId:int}/likeorunlike")]
        public ActionResult LikeOrUnlike (int postId, [FromQuery] int userId)
        {

            Post post = _postRepository.LikeOrUnlikePost(postId, userId);
            return NoContent();
        }

        [HttpPatch]
        [Route("{postId:int}/updatecontent")]
        public ActionResult UpdateContent(int postId, [FromQuery] PostDto postDto )
        {
            var post = _postRepository.UpdateContent(postId, postDto);
            if (post is null)
                return NotFound($"No post with {postId} found");

            return NoContent();
        }

        [HttpDelete]
        [Route("{postId:int}")]
        public ActionResult DeletePost(int postId, [FromQuery] int userId)
        {
            var post = _postRepository.GetPostById(postId);
            if (post is null)
                return NotFound($"No post with {postId} found");

            _postRepository.DeletePost(postId, userId);
            return NoContent();
        }

    }
}
