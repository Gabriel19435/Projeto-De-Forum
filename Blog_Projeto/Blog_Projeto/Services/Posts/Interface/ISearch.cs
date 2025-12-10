using Blog_Projeto.Models.dto;

namespace Blog_Projeto.Services.Posts.Interface
{
    public interface ISearch
    {
        public Task<(List<CompletePost_dto>, bool)> search(string Procura, string Type);
    }
}
