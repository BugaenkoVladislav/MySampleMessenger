using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server.App;
using Server.Entities;

namespace Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController(MyDbContext db) : ControllerBase
    {
        


        [HttpGet("GetUserFromId/{id}")]
        public async Task<User> GetUserFromId(long id)
        {
            return  await db.Users.FirstAsync(x => x.Id == id);
        } 
        
        [HttpPost("SignIn")]
        public async Task<string> SignIn(LoginPassword loginPassword)
        {
            var user = await db.Users.FirstAsync(x =>
                x.LoginPassword.Password == loginPassword.Password && x.LoginPassword.Email == loginPassword.Email);
            var role = user.IsAdmin == true ? "Admin" : "User";
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Username),
                new(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                claims:claims, 
                audience:AuthOptions.AUDIENCE, 
                issuer:AuthOptions.ISSUER,
                expires:DateTime.Now.AddDays(10),
                signingCredentials:new SigningCredentials(AuthOptions.GetSecurityKey(),SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
