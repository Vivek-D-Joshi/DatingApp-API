using API.DbEntities;
using API.Services.Definition;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        //Steps to create a Token in string 
        /*
         * To serialize a Token use tokenhandler.WriteToken(param) method
           parameter - token
          
         * to create a token use tokenHandler.CreateToken(param) method
           parameter - tokenDescriptor
          
         * tokenDescriptor - It is an object of an SecurityTokenDescriptor class.
           properties - 1.Subject: - The claims about the user (in this case, the user's name).
                        2.Expires: - The token's expiration time, which is set to 7 days from the current time.
                        3.SigningCredentials: - The credentials used to sign the token (previously defined creds).

         * creds(object of class SigningCredentials)
           Parameters: 1.Key - a security key(string).
                       2.Alogorithm - Alogrithm for signing a key

         * claims - claims are statements about the user that will be included in the JWT. 
                    In this case, the code creates a single claim with the key JwtRegisteredClaimNames.NameId 
                    and the user's name as the value. This claim represents the user's name and can be used to identify the user. 
         */
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Name)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}