

using blog_app_common.GenericResponse;
using blog_app_services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace blog_app_services.ServiceRepository
{
    public class AuthService : IAuthService
    {
        #region AuthenticateUSer
        public async Task<JsonResult> AuthUser(string password)
        {
            try
            {
                if (!String.IsNullOrEmpty(password))
                {
                    if (password == "User@123")
                    {
                        string token = CreateJwt();
                        return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.Success, Data = token, StatusCode = StatusCodes.OK, Result = true });
                    }
                    else
                    {
                        return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InvalidCredentials, StatusCode = StatusCodes.Unauthorized, Result = false });
                    }
                }
                else
                {
                    return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InvalidCredentials, StatusCode = StatusCodes.Unauthorized, Result = false });
                }
            }
            catch
            {
                return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = StatusCodes.BadRequest, Result = false });

            }
        }
        #endregion

        #region CreateJwt
        private static string CreateJwt()
        {
            try
            {
                var jwtTokenHaandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("Blog-Website_Secreat_Key_Is_Demo_With256Bits");

                var credetials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    SigningCredentials = credetials,
                    Expires = DateTime.Now.AddDays(1)
                };

                var token = jwtTokenHaandler.CreateToken(tokenDescriptor);
                return jwtTokenHaandler.WriteToken(token);
            }
            catch
            {
                return "";
            }
        }
        #endregion
    }
}
