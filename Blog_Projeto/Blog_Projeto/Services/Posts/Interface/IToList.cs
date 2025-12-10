using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;

namespace Blog_Projeto.Services.Posts.Interface
{
    public interface IToList
    {
        public Task<List<CompletePost_dto>> tolist(string ordem);
    }
}
