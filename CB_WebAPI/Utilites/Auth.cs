using AF.DataEntities.Context;
using CB_DataEntity.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CB_WebAPI.Utilites
{
    public class Auth : IJwtAuth
    {
      
        private readonly string key;

        SpContext contex;
        public Auth(string key )
        {
            this.key = key;
            
        }
        public string Authentication(UsersRequest obj)
        {
            // Get the User Detail From Database.
            var UsersResponse = GetUserDetail(obj);

            if (UsersResponse == null)
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, UsersResponse.user_name),
                        new Claim("password_attempt",UsersResponse.failed_password_attempt_count)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    
    public Users GetUserDetail(UsersRequest obj)
        {
            SpContext contex = new SpContext();
            var  res= contex.Users.FirstOrDefault(res=> res.user_id== obj.user_id);
            if (obj.user_id != res.user_id && obj.password != res.password)
            {
                return null ;
            }
            return res;
        }

    }
}
