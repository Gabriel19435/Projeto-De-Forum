using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Blog_Projeto.Services.Profile.Profile_Repository
{
    public interface IProfile_Services
    {
        public Task<ResponseModel<DadosUser>> RegisterUser(DadosUser_dto User);

        public Task<ResponseModel<DadosUser>> Login(DadosUser_dto User);

        public Task<ResponseModel<DadosUser>> Update(DadosUser User, IFormFile Photo, int id, string deleted);

        public Task<DadosUser> Find(int id);

        public Task Remove(int id);

        public Task<(ResponseModel<List<DadosPost>>, string, string, DateTime, string)> UserPage(int Owner);
    }
}
