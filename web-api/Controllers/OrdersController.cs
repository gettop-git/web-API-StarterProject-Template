using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService orderservice;
        public OrdersController(IOrderService orderservice)
        {
            this.orderservice = orderservice;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await orderservice.GetOrderById(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NoContent();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            Order neworder = await orderservice.AddOrder(order);
            if (neworder == null)
            {
                return BadRequest("Invalid order data");
            }



            return CreatedAtAction(nameof(Get), new { id = neworder.Id }, neworder);

        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
