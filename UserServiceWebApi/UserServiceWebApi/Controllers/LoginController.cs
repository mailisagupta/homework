using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private UserDetailsContext _userContext;
        private EncryptionDecryption _ed;
        
        public LoginController(UserDetailsContext userContext, EncryptionDecryption ed)
        {
            _ed = ed;
            _userContext = userContext;
            
        }


        // GET: api/<LoginController>
        [HttpGet]
        public dynamic Get(string userEmail, string userpassword)
        {
           
            User user = new User();
            string epassword = _ed.EncodePasswordToBase64(userpassword);
            
            user = _userContext.Users.FirstOrDefault(u => u.UserEmail == userEmail && u.UserPassword == epassword);

            
            if (user == null)
            {
                return "No match found in db";
            }
            else {
                var token = TokenHelper.GetToken(userEmail, userpassword);
                return new { Token = token };
            }
            
        }

       

        // POST api/<LoginController>
        [HttpPost]
        public dynamic Post([FromBody] TokenRequest tokenRequest)
        {

            var token = TokenHelper.GetToken(tokenRequest.UserEmail, tokenRequest.UserPassword);
            return new { Token = token };
        }

        [HttpDelete]
        public dynamic Delete(string token)
        {
           var _token = TokenHelper.DecodeToken(token);
            _token.Expires=DateTime.UtcNow;

            var jsonString = JsonConvert.SerializeObject(_token);
            var encryptedJsonString = _ed.EncodePasswordToBase64(jsonString);
           
            return new { Token = encryptedJsonString };

        }

    }
}
