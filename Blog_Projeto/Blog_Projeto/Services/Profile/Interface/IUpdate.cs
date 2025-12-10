using Blog_Projeto.Models;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Site_Blog.Service.Profile.Interface
{
    public interface IUpdate
    {
        public Task<ResponseModel<DadosUser>> update(DadosUser User, IFormFile Photo, int id, string deleted);
    }
}
