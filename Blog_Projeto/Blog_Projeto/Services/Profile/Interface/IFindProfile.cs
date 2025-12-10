using Blog_Projeto.Models;

namespace Site_Blog.Service.Profile.Interface
{
    public interface IFindProfile
    {
        public Task<DadosUser> find(int id);
    }
}
