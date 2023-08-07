﻿using backend.businesslogic.Interfaces;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IAuthBL service;
        private readonly int expirationMin;

        public AuthController(IConfiguration _configuration, IAuthBL _service) {
            secretKey = _configuration["JWTConfig:secretKey"];
            service = _service;
            expirationMin = 10;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<String>>> AuthLogin([FromBody] authLoginDTO request) 
        {

            SqlRspDTO rsp = await service.AuthUser(request);

            if (rsp.nCod > 0)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim("userId", rsp.nCod.ToString()));
                claims.AddClaim(new Claim("userName", rsp.sMsj));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(expirationMin),
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

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<List<OpcionDTO>>>> getListOpcionByIdUsuarioComp(int nIdUsuario, int nIdCompania)
        {

            ApiResponse<List<OpcionDTO>> response = new ApiResponse<List<OpcionDTO>>();

            try
            {
                var result = await service.ListOpcionByIdUsuario(nIdUsuario, nIdCompania);

                response.success = true;
                response.data = (List<OpcionDTO>) result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<List<CompaniaDTO>>>> getListCompaniaByIdUsuario(int nIdUsuario)
        {

            ApiResponse<List<CompaniaDTO>> response = new ApiResponse<List<CompaniaDTO>>();

            try
            {
                var result = await service.ListCompaniaByIdUsuario(nIdUsuario);

                response.success = true;
                response.data = (List<CompaniaDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<String>>> AuthRefresh()
        {
            ApiResponse<String> response = new ApiResponse<String>();

            try
            {
                var token = this.Request.Headers.Authorization.First(x => x.StartsWith("Bearer")).Split(' ')[1];

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenSecurity = tokenHandler.ReadToken(token.ToString());

                if (tokenSecurity.ValidTo.AddMinutes(-5) < DateTime.UtcNow) 
                { 

                    var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();

                    claims.AddClaim(UserIdClaim(token));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(expirationMin),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                    token = tokenHandler.WriteToken(tokenConfig);
                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<String> { success = true, data = token, errMsj = "" });
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        private Claim UserIdClaim(string token)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;
            validationParameters.ValidateAudience = false;
            validationParameters.ValidateIssuer = false;

            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            ClaimsPrincipal claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validatedToken);

            return claimsPrincipal.Claims.First(c => c.Type == "userId");
        }
    }
}
