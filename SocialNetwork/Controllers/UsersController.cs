using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkLibrary.Repositories.Posts;
using SocialNetworkLibrary.Repositories.Users;
using SocialNetworkLibrary.Models.Users;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Dtos.Users;
using System.ComponentModel.DataAnnotations;
using SocialNetworkLibrary.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    //Controller route api/users
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPostRepository _todoRepository;
        private readonly IUserRepository _userRepository;

        public UsersController(IPostRepository todoRepository, IUserRepository userRepository)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        /// <response code="200">If the users are succesfully found</response>
        /// <response code="400">If invalid properties</response>
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return users;
            }
            catch(UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns a specific user with a id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The user with the id</returns>
        /// <response code="200">If the user was successfully found</response>
        /// <response code="400">If invalid properties</response>
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = _userRepository.GetUser(id);
                return user;
            }
            catch(UserException e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Adds a new user with properties (string UserName, string Password, string EmailAdress)
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/users/adduser
        ///     {
        ///             "UserName": "ExampleUserName",
        ///             "Password": "ExamplePassword",
        ///             "EmailAdress": "Example@EmailAdress"
        ///     }
        /// </remarks>
        /// <param name="userDto"></param>
        /// <response code="204">If the user is succesfully created</response>
        /// <response code="400">If the user contains invalid property</response>
        [HttpPost]
        [Route("adduser")]
        public ActionResult<User> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                _userRepository.AddUser(userDto);
                return NoContent();
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Removes a specific user with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The user with the id</returns>
        /// <response code="204">If the user was sucessfully removed</response>
        /// <response code="400">If invalid properties</response>
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult RemoveUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return NoContent();
            }
            catch(UserException e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
