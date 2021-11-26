using CB_DataEntity.Model;
using CB_WebAPI.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;         
        public LoginController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }

        [AllowAnonymous] // Bypass All Authentication . Any one Can Call this Method. 
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody]  UsersRequest obj)
        {
            var token = jwtAuth.Authentication(obj);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
    }
