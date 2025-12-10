using Blog_Projeto.Data;
using Blog_Projeto.Services.Posts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Services.Posts.Class
{
    public class DeletePost : IDeletePost
    {
        private readonly Blog_Context _context;
        private string CaminhoRoot;
        public DeletePost(Blog_Context context, IWebHostEnvironment Web)
        {
            _context = context;
            CaminhoRoot = Web.WebRootPath;
        }
        public async Task<bool> Deletar(int id, int UserId)
        {
            var item = await _context.DadosPost.FindAsync(id);
            if (item != null && item.PostOwner == UserId)
            {
                string NomeCompleto = item.Foto.Replace("/Postimg/", "");
                string CaminhoCompleto = Path.Combine(CaminhoRoot, "Postimg", NomeCompleto);

                if (System.IO.File.Exists(CaminhoCompleto))
                {
                    System.IO.File.Delete(CaminhoCompleto);
                }

                _context.DadosPost.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
