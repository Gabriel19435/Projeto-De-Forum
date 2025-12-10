using Blog_Projeto.Models;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Blog_Projeto.Services.Profile.Interface
{
    public interface IUserPage
    {
        public Task<(ResponseModel<List<DadosPost>>, string, string, DateTime, string)> userpage(int Owner);
    }
}
