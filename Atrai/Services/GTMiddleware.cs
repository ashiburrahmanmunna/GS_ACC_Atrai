﻿using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrai.Services
{
    public class GTMiddleware
    {
        private readonly RequestDelegate _next;
        public GTMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IUserService service)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                    attachUserToContext(context, service, token);

                await _next(context);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes("THIS IS THE FIRST TIME CREATE JWT TOKEN FOR GTR");
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
                var comId = int.Parse(jwtToken.Claims.First(x => x.Type == "CurrentComId").Value);


                // attach user to context on successful jwt validation
                // 
                var userinfo = userService.GetUser(userId, comId);
                userinfo.CurrentComId = comId;///by fahad for test purpose.
                context.Items["User"] = userinfo;// systemContext.tblLogin_User.Where(s=>s.EmpId==userId).FirstOrDefault(); 
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }

    }
}
