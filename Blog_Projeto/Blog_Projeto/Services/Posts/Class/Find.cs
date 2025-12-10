using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Services.Posts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Services.Posts.Class
{
    public class Find : IFind
    {
        private readonly Blog_Context _context;
        public Find(Blog_Context context)
        {
            _context = context;
        }
        public async Task<DadosPost> find(int id)
        {
            var item = await _context.DadosPost.FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }
    }
}
