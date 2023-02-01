using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;

namespace MyWebSite.Controllers
{
    using AutoMapper;
    using DTO;
    using MyWeb;
    using Service;
    using Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;
        ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserService x, ILogger<UserController> logger, IMapper mapper)
        {
            _iUserService = x;
            _logger = logger;
            _mapper = mapper;

        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<UserDTOwithoutPassword> Get([FromQuery] string userName, [FromQuery] string code)
        {
                var user = await _iUserService.GetUsers(userName, code);
                var userDTOwithoutPassword = _mapper.Map<User, UserDTOwithoutPassword>(user);
                _logger.LogInformation("user" + userName + "failed to log in");
                return userDTOwithoutPassword;

}

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserDTOwithoutPassword> Post([FromBody] UserDto userDTO)
        {
            
            var user = _mapper.Map<UserDto, User>(userDTO);
            User backedUser = await _iUserService.AddUser(user);
            var userDTOwithoutPassword = _mapper.Map<User, UserDTOwithoutPassword>(backedUser);
            return userDTOwithoutPassword;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDto updateduserDTO)
        {
            var user = _mapper.Map<UserDto, User>(updateduserDTO);
            _iUserService.UpdateUser(id, user);
            return;
        }


       
    }
}

