using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using UserDataAccess.Db;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticator]
    public class UsersController : ControllerBase
    {
        private UserDetailsContext _userContext;
        private EncryptionDecryption _ed;
        
        public UsersController(UserDetailsContext userContext, EncryptionDecryption ed)
        {    _ed = ed; 
            _userContext = userContext;
            
        }
        // GET: api/<UsersController>
        [HttpGet]
       
        public async Task<ActionResult<List<User>>> Get()
        {
            
            List<User> users = new List<User>();
            users = await _userContext.Users.ToListAsync();
            foreach(var user in users)
            {
                user.UserPassword = _ed.DecodeFrom64(user.UserPassword);
            }
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
       
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var user= await _userContext.Users.FindAsync(id);
            
           
            if (user == null) { return NotFound(new ApiResponse(404, "User not found.")); }
            else
            {
                user.UserPassword = _ed.DecodeFrom64(user.UserPassword);
                return Ok(user);
            }
            
            
        }

        // POST api/<UsersController>
        [HttpPost]
       

        public async Task<ActionResult<List<User>>> Post(User user)
        { user.CreatedDate = DateTime.Now;
            user.UserId = Guid.NewGuid();
            if (ModelState.IsValid) {

                user.UserPassword = _ed.EncodePasswordToBase64(user.UserPassword);

                _userContext.Users.Add(user);
                int Count = await _userContext.SaveChangesAsync();
                if (Count > 0)
                {
                    return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
                }
                else
                {
                    return StatusCode(500, (new ApiResponse(500, "Internal Server Error")));
                }
               
            }
            else { return BadRequest(new ApiResponse(400, "Bad request")); }
            

        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, User value)
        {
            if (!ModelState.IsValid) { 
            return BadRequest((new ApiResponse(400, "Not a valid model"))); }

            else {
                var user = _userContext.Users.FirstOrDefault(e => e.UserId == id);

                if (user != null)
                {
                    user.UserPassword = _ed.EncodePasswordToBase64(value.UserPassword);
                    user.UserEmail = value.UserEmail;

                    _userContext.SaveChangesAsync();
                }
                else
                {
                    return NotFound(new ApiResponse(404, "User not found."));
                }


                return Ok();
            }
            
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userContext.Users.FirstOrDefault(e => e.UserId == id);
            if(user== null)
            {
                return NotFound(new ApiResponse(404, "User not found."));
            }
            else {
                user.UserPassword = _ed.DecodeFrom64(user.UserPassword);
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();
                return Ok(user);
            }

           
        }


       

    }
}
