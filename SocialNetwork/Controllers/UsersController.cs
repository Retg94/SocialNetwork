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

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user is null)
                return NotFound(user);
            return user;
        }

        [HttpPost]
        [Route("adduser")]
        public ActionResult<User> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                User user = _userRepository.AddUser(userDto);
                return user;
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult RemoveUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user is null)
                return NotFound($"No post with {id} found");
            _userRepository.DeleteUser(id);
            return NoContent();
        }

    }
}
