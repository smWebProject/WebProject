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
        ILogger<UserController> _logger;    
        public UserController(IUserService x, ILogger<UserController> logger)
        {
            _iUserService = x;
            _logger = logger;   
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<User?> Get([FromQuery] string userName, [FromQuery] string code)
        {
            //try
            //{
                var user = await _iUserService.GetUsers(userName, code);
                _logger.LogInformation("user" + userName + "failed to log in");

            return user;
            //}
           // catch (Exception ex) {
               // _logger.LogError("Error Happenned!!!",ex.Message,ex.StackTrace);
                //return null;    
            //}
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

