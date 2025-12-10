using Blog_Projeto.Data;
using Blog_Projeto.Services.Profile.ProfExtra;
using Site_Blog.Service.Profile.Interface;

namespace Site_Blog.Service.Profile.Class
{
    public class DeleteProfile : IDeleteProfile
    {
        private readonly Blog_Context _context;
        private string Root;
        public DeleteProfile(Blog_Context context, IWebHostEnvironment web)
        {
            _context = context;
            Root = web.WebRootPath;
        }
        public async Task remove(int id)
        {
            var item = await _context.DadosUser.FindAsync(id);
            ProfilePics.DeletePhoto(Root, item.Photo);

            _context.DadosUser.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
