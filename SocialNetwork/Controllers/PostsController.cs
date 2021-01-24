using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkLibrary.Dtos.Posts;
using SocialNetworkLibrary.Models.Posts;
using SocialNetworkLibrary.Repositories.Posts;
using SocialNetworkLibrary.Repositories.Users;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostsController(IPostRepository todoRepository, IUserRepository userRepository)
        {
            _postRepository = todoRepository;
            _userRepository = userRepository;
        }
    }
}
