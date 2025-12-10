using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Services.Posts.Interface;
using Blog_Projeto.Services.Posts.PostExtra;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Blog_Projeto.Services.Posts.Class
{
    public class Edit : IEdit
    {
        private readonly Blog_Context _context;
        private string CaminhoRoot;
        public Edit(Blog_Context context, IWebHostEnvironment Web)
        {
            _context = context;
            CaminhoRoot = Web.WebRootPath;
        }
        public async Task<ResponseModel<DadosUser>> Editar(int id, string Titulo, string Descriçao, IFormFile Foto, string delete)
        {
            ResponseModel<DadosUser> Response = new ResponseModel<DadosUser>();
            var item = _context.DadosPost.Find(id);
            if (item == null || string.IsNullOrEmpty(Titulo) || string.IsNullOrEmpty(Descriçao))
            {
                return null;
            }
            if (delete == "deleteimg")
            {
                string NomeCompleto = (item.Foto ?? "").Replace("/Postimg/", "");
                string CaminhoCompleto = Path.Combine(CaminhoRoot, "Postimg", NomeCompleto);

                if (System.IO.File.Exists(CaminhoCompleto))
                {
                    System.IO.File.Delete(CaminhoCompleto);
                }

                item.Foto = "deleted";
            }
            if (Foto != null)
            {
                item.Foto = await GerarImg.GerarImagem(Foto, "Postimg", CaminhoRoot);
            }
            if(Titulo != null)
            {
                item.Titulo = Titulo;
            }
            if (Descriçao != null)
            {
                item.Descriçao = Descriçao;
            }
            _context.DadosPost.Update(item);
            await _context.SaveChangesAsync();

            Response.Erro = false;
            return Response;
        }
    }
}
