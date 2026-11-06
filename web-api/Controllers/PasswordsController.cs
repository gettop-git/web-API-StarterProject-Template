using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
        
    {

        IUserService passwordservice;
        public PasswordsController(IUserService userservice)
        {
            this.passwordservice = userservice;
        }
        // GET: api/<PasswordsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordsController>
        [HttpPost ("password")]
        public IActionResult Post([FromBody] string password)
        {
            var result = passwordservice.CheckPassword(password);

            return Ok(result);
        }

        // PUT api/<PasswordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
