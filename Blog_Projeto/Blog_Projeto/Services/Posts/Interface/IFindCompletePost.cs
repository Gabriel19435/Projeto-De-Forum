using Blog_Projeto.Models.dto;

namespace Blog_Projeto.Services.Posts.Interface
{
    public interface IFindCompletePost
    {
        public Task<CompletePost_dto> findcomplete(int id);
    }
}
