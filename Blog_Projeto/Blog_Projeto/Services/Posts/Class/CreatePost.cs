using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Posts.Interface;
using Blog_Projeto.Services.Posts.PostExtra;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Services.Posts.Class
{
    public class CreatePost : ICreatePost
    {
        private readonly Blog_Context _context;
        private string CaminhoRoot;
        public CreatePost(Blog_Context context, IWebHostEnvironment Web)
        {
            _context = context;
            CaminhoRoot = Web.WebRootPath;
        }
        public async Task<List<CompletePost_dto>> Criarpost(IFormFile Foto, string Titulo, string Descriçao, int UserId)
        {
            var erro = await _context.DadosPost
                .Join(_context.DadosUser,
                    post => post.PostOwner, user => user.Id,
                    (post, user) => new CompletePost_dto
                    {
                        UserPhoto = user.Photo,
                        UserName = user.Name,

                        Id = post.Id,
                        PostOwner = post.PostOwner,
                        Data = post.Data,
                        Titulo = post.Titulo,
                        Descriçao = post.Descriçao,
                        Foto = post.Foto
                    })
                .ToListAsync();

            if (string.IsNullOrEmpty(Titulo) || string.IsNullOrEmpty(Descriçao))
            {
                return erro;
            }
            if (Titulo.Length < 5 || Descriçao.Length < 5)
            {
                return erro;
            }
            var item = new DadosPost
            {
                PostOwner = UserId,
                Titulo = Titulo,
                Descriçao = Descriçao,
                Foto = "deleted",
                Data = DateTime.Now
            };

            if (Foto != null)
            {
                var _Foto = await GerarImg.GerarImagem(Foto, "Postimg", CaminhoRoot);
                item.Foto = _Foto;
            }

            _context.DadosPost.Add(item);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
