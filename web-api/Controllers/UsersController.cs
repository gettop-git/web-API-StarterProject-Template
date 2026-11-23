using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zxcvbn;
using Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userservice; 
        public UsersController(IUserService userservice)
        {
            this.userservice = userservice;
        }
        //string Filepath = "Data.txt";
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Chavi", "Giti" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            
            User user= await userservice.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            int score = userservice.CheckPassword(user.Password);
            if (score < 2)
                return BadRequest("הסיסמה חלשה מדי");

            User newuser= await userservice.AddUser(user);
            if (newuser == null)
    {
                return BadRequest("Invalid user data");
            }
            
            
            
            return CreatedAtAction(nameof(Get), new { id = newuser.Id }, newuser);
        }

        //POST api/<Users>/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Userin Userin)
        { 
            User InUser= await userservice.UserLogIn(Userin);
          
            if(InUser == null)
            {
                return NotFound("User not found");
            }
            return Ok(InUser);


        }




        



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            int score = userservice.CheckPassword(user.Password);
            if (score < 2)
                return BadRequest("הסיסמה חלשה מדי");
            User updateUser= await userservice.UpdateUserById(id,user);
            if(updateUser == null)
            {
                return NoContent();
            }

            return Ok(updateUser);
            
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
