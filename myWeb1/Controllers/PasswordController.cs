using Microsoft.AspNetCore.Mvc;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {


        // POST api/<PasswordController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string code)
        {
            Result result = Zxcvbn.Core.EvaluatePassword(code);
            return result.Score<=2 ? BadRequest() : result.Score;
        }


    }
}
