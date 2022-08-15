using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquareController : ControllerBase
    {
        // GET: api/<SquareController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SquareController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "square of " + id.ToString() + ": " + (id * id).ToString();
        }

        // POST api/<SquareController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SquareController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SquareController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
