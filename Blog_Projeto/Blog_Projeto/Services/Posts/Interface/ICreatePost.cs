using Blog_Projeto.Models.dto;

namespace Blog_Projeto.Services.Posts.Interface
{
    public interface ICreatePost
    {
        public Task<List<CompletePost_dto>> Criarpost(IFormFile Foto, string Titulo, string Descriçao, int UserId);
    }
}
