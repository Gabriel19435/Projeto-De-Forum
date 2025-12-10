using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Blog_Projeto.Services.Posts.Posts_Repository
{
    public interface IPosts_Service
    {
        public Task<List<CompletePost_dto>> ToList(string ordem);

        public Task<CompletePost_dto> FindCompletePost(int id);

        public Task<DadosPost> Find(int id);

        public Task<bool> DeletePost(int id, int UserId);

        public Task<List<CompletePost_dto>> CriarPost(IFormFile Foto, DadosPost post, string UserEmail);

        public Task<ResponseModel<DadosUser>> Editar(int id, DadosPost User, IFormFile Foto, string delete);

        public Task<(List<CompletePost_dto>, bool)> Search(string Procura, string Type);
    }
}
