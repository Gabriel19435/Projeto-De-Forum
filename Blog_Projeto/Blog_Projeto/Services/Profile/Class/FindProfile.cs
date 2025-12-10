using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Site_Blog.Service.Profile.Interface;

namespace Site_Blog.Service.Profile.Class
{
    public class FindProfile : IFindProfile
    {
        private readonly Blog_Context _context;
        public FindProfile(Blog_Context context)
        {
            _context = context;
        }
        public async Task<DadosUser> find(int id) 
        {
            var item = await _context.DadosUser.FindAsync(id);
            return item;
        }
    }
}
