using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;

namespace MyWebSite.Controllers
{
    using Service;
    using T_Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public UserController(IUserService x)
        {
            _iUserService = x;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<User?> Get([FromQuery] string userName, [FromQuery] string code)
        {
            var user=await _iUserService.GetUsers(userName, code);
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            User resUser = await _iUserService.AddUser(user);
            return resUser;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User updateduser)
        {
            _iUserService.UpdateUser(id, updateduser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

