using HelloWebService.Models;
using HelloWorldService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public static List<Contact> contacts = new List<Contact>();
        public static int id = 100;

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //foreach(var contact in contacts)
            //{
            //    if(contact.Id == id)
            //    {
            //        return contact;
            //    }
            //}
            //return null;

            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if(contact == null)
            {
                return NotFound(null);
            }
            return Ok(contact);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {
            if (value.Name == null || value.Name=="")
            {
                return BadRequest(new ErrorResponse { Message = "null or empty name", Field="Name" }) ;

            }
           
            
            else
            {
                value.Id = id++;
                value.DateAdded = DateTime.Now;
                contacts.Add(value);
                ///contacts.Add(new Contact() { Id = id, Name=value.Name,DateAdded=DateTime.Now }) ;
                ///
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            }

        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                contact.Name = value.Name;
                contact.Phones=value.Phones;
                return Ok(contact);
            }
            else
            {
                return NotFound("id not found");
            }

        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            { var rowDeleted = contacts.RemoveAll(t => t.Id == id);
                return Ok();
            }
            else
            {
                return NotFound("id not found");
            }
                
        }
    }
}