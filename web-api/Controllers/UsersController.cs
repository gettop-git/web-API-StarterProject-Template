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
        UserService userservice=new UserService();
        string Filepath = "Data.txt";
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Chavi", "Giti" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            
            User user=userservice.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
         
            User newuser=userservice.AddUser(user);
            if (newuser == null)
    {
                return BadRequest("Invalid user data");
            }
            
            
            
            return CreatedAtAction(nameof(Get), new { id = newuser.Id }, newuser);
        }

        //POST api/<Users>/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Userin Userin)
        { 
            User InUser=userservice.UserLogIn(Userin);
          
            if(InUser == null)
            {
                return NotFound("User not found");
            }
            return Ok(InUser);


        }




        // POST api/<UsersController>
        [HttpPost("password")]
        public IActionResult Post([FromBody] string password)
        {
           

    
            var result =userservice.CheckPassword(password);

            return Ok(result);


        }



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            User updateUser=userservice.UpdateUserById(id,user);
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
