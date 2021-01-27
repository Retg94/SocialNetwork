using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Models.Users;
using SocialNetworkLibrary.Repositories;
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

        /// <summary>
        /// Returns a specific post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The post with the id</returns>
        /// <response code="200">If the post is succesfully found</response>
        /// <response code="400">If the post was not found</response>
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Post> GetPost(int id)
        {
            try
            {
                var post = _postRepository.GetPostById(id);
                return post;
            }
            catch(PostException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        /// <response code="200">If the users was successfully found</response>
        /// <response code="400">If no users was found</response>
        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            try
            {
                var posts = _postRepository.GetAllPosts();
                return posts;
            }
            catch(PostException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Add a new post with postDto-properties (string Content, int UserId)
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/posts/addpost
        ///     {
        ///             "Content": "I like cakes, do you also like cakes?",
        ///             "UserId": 1
        ///     }
        /// </remarks>
        /// <param name="postDto"></param>
        /// <returns>The post with properties</returns>
        /// <response code="204">If the post was sucessfully created</response>
        /// <response code="400">If invalid properties</response>
        [HttpPost]
        [Route("addpost")]
        public ActionResult<Post> AddPost([FromBody] PostDto postDto)
        {
            try
            {
                var user = _userRepository.GetUser(postDto.UserId);
                _postRepository.AddPost(postDto);
                return NoContent();
            }
            catch(PostException e)
            {
                return BadRequest(e.Message);
            }
            catch(UserException e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Enables a user with userId to like or unlike a post with postId
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <response code="204">If like or unlike was successfully done</response>
        /// <response code="400">If invalid properties</response>
        [HttpPatch]
        [Route("{postId:int}/likeorunlike")]
        public ActionResult LikeOrUnlike (int postId, [FromQuery] int userId)
        {
            try
            {
                Post post = _postRepository.LikeOrUnlikePost(postId, userId);
                return NoContent();
            }
            catch(PostException e)
            {
                return BadRequest(e.Message);
            }
            catch(UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Updates a post by id postId with properties postDto, where UserId is the user trying to update Content
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="postDto"></param>
        /// <returns></returns>
        /// <response code="204">If post was successfully updated</response>
        /// <response code="400">If invalid properties</response>
        [HttpPatch]
        [Route("{postId:int}/updatecontent")]
        public ActionResult UpdateContent(int postId, [FromQuery] PostDto postDto )
        {
            try
            {
                var post = _postRepository.UpdateContent(postId, postDto);
                return NoContent();
            }
            catch(PostException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletes a post with id by userId
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <response code="204">If post was successfully deleted</response>
        /// <response code="400">If invalid properties</response>
        [HttpDelete]
        [Route("{postId:int}")]
        public ActionResult DeletePost(int postId, [FromQuery] int userId)
        {
            try
            {
                var post = _postRepository.GetPostById(postId);
                _postRepository.DeletePost(postId, userId);
                return NoContent();
            }
            catch(PostException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
