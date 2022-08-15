using Newtonsoft.Json;

namespace UserServiceWebApi
{

    public class Token
    {
        public string UserEmail { get; set; }
        public DateTime Expires { get; set; }
    }

    public class TokenHelper
    {


        
        public static  string GetToken(string userEmail, string password)
        {
            EncryptionDecryption _ed = new EncryptionDecryption();
            //User user = new User();
            //string epassword = _ed.EncodePasswordToBase64(password);
            //using (UserDetailsContext _userContext = new UserDetailsContext())
            //{
            //    user = _userContext.Users.FirstOrDefault(u => u.UserEmail == userEmail && u.UserPassword == epassword);

            //}
            //if (user == null)
            //{
            //    return "No match found in db";
            //}
            //else
            //{
                var token = new Token
                {
                    UserEmail = userEmail,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                };
                var jsonString = JsonConvert.SerializeObject(token);
                var encryptedJsonString = _ed.EncodePasswordToBase64(jsonString);
                return encryptedJsonString;
            


        }

        public static Token DecodeToken(string token)
        {
            EncryptionDecryption _ed = new EncryptionDecryption();
            var decryptedJsonString = _ed.DecodeFrom64(token);
            var tokenObject = JsonConvert.DeserializeObject<Token>(decryptedJsonString);
            //if (tokenObject.Expires < DateTime.UtcNow)
            //{
            //    return null;
            //}
            return tokenObject;
        }
    }
}

    
