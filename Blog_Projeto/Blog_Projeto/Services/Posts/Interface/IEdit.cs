using Blog_Projeto.Models;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Blog_Projeto.Services.Posts.Interface
{
    public interface IEdit
    {
        public Task<ResponseModel<DadosUser>> Editar(int id, string Titulo, string Descriçao, IFormFile Foto, string delete);
    }
}
