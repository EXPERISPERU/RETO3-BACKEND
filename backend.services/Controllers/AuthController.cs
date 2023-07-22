using backend.businesslogic.Interfaces;
using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IAuthBL service;

        public AuthController(IConfiguration _configuration, IAuthBL _service) {
            secretKey = _configuration["JWTConfig:secretKey"];
            service = _service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<String>>> AuthLogin([FromBody] authLoginDTO request) {

            SqlRspDTO rsp = await service.AuthUser(request);

            if (rsp.nCod > 0)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim("userId", rsp.nCod.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<String> { success = true, data = token, errMsj = "" });
            }
            else {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<String> { success = false, data = "", errMsj = rsp.sMsj });
            }
        }
    }
}
