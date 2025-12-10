using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Services.Profile.ProfExtra;
using Site_Blog.Service.Profile.Interface;

namespace Blog_Projeto.Services.Profile.Class
{
    public class Register : IRegister
    {
        private readonly Blog_Context _context;
        private string Root;
        public Register(Blog_Context context, IWebHostEnvironment web)
        {
            _context = context;
            Root = web.WebRootPath;
        }

        public async Task<ResponseModel<DadosUser>> register(Models.dto.DadosUser_dto User)
        {
            ResponseModel<DadosUser> Response = new ResponseModel<DadosUser>();
            if (User.Name.Length < 4 || User.Name.Length > 30 || string.IsNullOrWhiteSpace(User.Name))
            {
                Response.ViewMessage = "The Name Must Have 10 Words Atleast";                
                return Response;
            }
            if (EmailValidation.EmailExists(User,_context))
            {
                Response.ViewMessage = "The Email Alredy Exists";
                return Response;
            }
            if (!EmailValidation.EmailValid(User.Email))
            {
                Response.ViewMessage = "The Email is Invalid";
                return Response;
            }
            if (User.Email.Length < 25 - 10 || User.Email.Length > 40 - 10)
            {
                Response.ViewMessage = "The Email is Too Long/Short";
                return Response;
            }
            if (User.Password.Length < 5 || User.Password.Length > 15)
            {
                Response.ViewMessage = "The Password are Too Long/Short";
                return Response;
            }
            if (User.Password != User.PasswordConfirm)
            {
                Response.ViewMessage = "The Passwords Are Diferent";
                return Response;
            }

            var UserPasswords = PasswordValidation.CrypPassword(User.Password);
            var item = new Models.DadosUser
            {
                Photo = ProfilePics.NoobPhoto(Root, User.Name),
                Name = User.Name,
                Email = User.Email.Replace(" ", ""),
                Descrition = "Null",
                Data = DateTime.Now,
                Passwordhash = UserPasswords.Passwordhash,
                PasswordKey = UserPasswords.PasswordKey
            };
            _context.DadosUser.Update(item);
            await _context.SaveChangesAsync();

            Response.Erro = false;
            return Response;
        }
    }
}
