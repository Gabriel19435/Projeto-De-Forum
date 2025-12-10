using Blog_Projeto.Models;

namespace Blog_Projeto.Services.Posts.Interface
{
    public interface IFind
    {
        public Task<DadosPost> find(int id);
    }
}
