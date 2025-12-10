using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.ProfExtra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Site_Blog.Service.Profile.Interface;
using System.Security.Claims;

namespace Site_Blog.Service.Profile.Class
{
    public class Login : ILogin
    {
        private readonly Blog_Context _context;
        private readonly IHttpContextAccessor _HttpContext;
        public Login(Blog_Context context, IHttpContextAccessor HttpContext)
        {
            _HttpContext = HttpContext;
            _context = context;            
        }
        public async Task<ResponseModel<DadosUser>> login(DadosUser_dto User)
        {
            ResponseModel<DadosUser> Response = new ResponseModel<DadosUser>();
            if (User.Email == null || User.Password == null || User.PasswordConfirm == null)
            {
                Response.ViewMessage = "Complete The Formularium";
                return Response;
            }
            if (!EmailValidation.EmailValid(User.Email))
            {
                Response.ViewMessage = "The Email is Invalid";
                return Response;
            }
            if (!EmailValidation.EmailExists(User,_context))
            {
                Response.ViewMessage = "The Email Dont Exists";
                return Response;
            }
            if (User.Password != User.PasswordConfirm)
            {
                Response.ViewMessage = "The Passwords Are Diferent";
                return Response;
            }
            var UserData = _context.DadosUser.FirstOrDefault(x => x.Email == User.Email);
            if (PasswordValidation.VerifyPassword(User.Password, UserData.Passwordhash, UserData.PasswordKey))
            {
                var claim = new List<Claim>
                {
                    new Claim("ProfilePhoto",UserData.Photo),
                    new Claim(ClaimTypes.Name,UserData.Name),
                    new Claim(ClaimTypes.Email,UserData.Email),
                    new Claim("ProfileIdentificator",UserData.Id.ToString()),
                };
                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await _HttpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                Response.Erro = false;
                return Response;
            }
            else
            {
                Response.ViewMessage = "The Passwords Are Incorrect";
                return Response;
            }
        }
    }
}
