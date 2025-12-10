using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Site_Blog.Service.Profile.Interface
{
    public interface ILogin
    {
        public Task<ResponseModel<DadosUser>> login(DadosUser_dto User);
    }
}
