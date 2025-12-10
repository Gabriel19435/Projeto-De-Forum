namespace Blog_Projeto.Services.Posts.Interface
{
    public interface IDeletePost
    {
        public Task<bool> Deletar(int id, int UserId);
    }
}
