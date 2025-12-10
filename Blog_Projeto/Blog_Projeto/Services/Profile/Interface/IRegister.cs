using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Site_Blog.Service.Profile.Interface
{
    public interface IRegister
    {
        public Task<ResponseModel<DadosUser>> register(DadosUser_dto User);
    }
}