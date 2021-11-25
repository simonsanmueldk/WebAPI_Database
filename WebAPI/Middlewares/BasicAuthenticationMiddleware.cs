using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Middlewares
{
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public BasicAuthenticationMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string apiString = httpContext.Request.Path.Value.ToUpper();
            if (apiString.Contains("USER/FIND") || apiString.Contains("ADULT/ALL"))
            {
                await _next.Invoke(httpContext);
                return;
            }

            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader !=null && authHeader.StartsWith("Basic"))
            {
                string encodeUsernamdAndPassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string usernameAndPassword = encoding.GetString(Convert.FromBase64String(encodeUsernamdAndPassword));
                int index = usernameAndPassword.IndexOf(":");
                var username = usernameAndPassword.Substring(0, index);
                var password = usernameAndPassword.Substring(index + 1);

                if (validateLogin(username,password))
                {
                    await _next.Invoke(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
            
        }

        private bool validateLogin(string username, string password)
        {
            try
            {
                User user = _userService.ValidateUser(username, password);
                if (user != null)
                    return true;
            }
            catch (Exception)
            {
            }
            return false;

        }
    }


    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}
