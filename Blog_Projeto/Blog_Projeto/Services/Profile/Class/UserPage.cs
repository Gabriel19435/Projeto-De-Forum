using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Services.Profile.Interface;
using Blog_Projeto.Services.Profile.ProfExtra;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Services.Profile.Class
{
    public class UserPage : IUserPage
    {
        private readonly Blog_Context _context;
        public UserPage(Blog_Context context)
        {
            _context = context;
        }
        public async Task<(ResponseModel<List<DadosPost>>, string, string, DateTime, string)> userpage(int Owner)
        {
            ResponseModel<List<DadosPost>> Response = new ResponseModel<List<DadosPost>>();
            var userData = _context.DadosUser.FirstOrDefault(x => x.Id == Owner);
            var item = await _context.DadosPost.Where(x => x.PostOwner == Owner).ToListAsync();

            Response.Model = item;
            Response.ViewMessage = item.Count().ToString();

            string Photo = userData.Photo;
            string Name = userData.Name;
            DateTime Data = (DateTime)userData.Data;
            string UserDesc = userData.Descrition;

            return (Response, Photo, Name, Data, UserDesc);
        }
    }
}
