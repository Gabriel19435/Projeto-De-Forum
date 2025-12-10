using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.Interface;
using Blog_Projeto.Services.Profile.ProfExtra;
using Site_Blog.Service.Profile.Interface;

namespace Blog_Projeto.Services.Profile.Profile_Repository
{
    public class Profile_Services : IProfile_Services
    {
        private readonly IRegister _register;
        private readonly ILogin _login;
        private readonly IUpdate _update;
        private readonly IFindProfile _find;
        private readonly IDeleteProfile _delete;
        private readonly IUserPage _userpage;
        public Profile_Services
            (IRegister register, ILogin login, IUpdate update,
            IFindProfile find, IDeleteProfile delete, IUserPage userpage)
        {
            _register = register;
            _login = login;
            _update = update;
            _find = find;
            _delete = delete;
            _userpage = userpage;
        }

        public async Task<ResponseModel<DadosUser>> RegisterUser(DadosUser_dto User)
        {
            var item = await _register.register(User);
            return item;
        }

        public async Task<ResponseModel<DadosUser>> Login(DadosUser_dto User)
        {
            var item = await _login.login(User);
            return item;
        }

        public async Task<ResponseModel<DadosUser>> Update(DadosUser User, IFormFile Photo, int id, string deleted)
        {
            var item = await _update.update(User, Photo, id, deleted);
            return item;
        }

        public async Task<DadosUser> Find(int id)
        {
            var item = await _find.find(id);
            return item;
        }

        public async Task Remove(int id)
        {
            await _delete.remove(id);
        }

        public async Task<(ResponseModel<List<DadosPost>>, string, string, DateTime, string)> UserPage(int Owner)
        {
            return await _userpage.userpage(Owner);
        }
    }
}
