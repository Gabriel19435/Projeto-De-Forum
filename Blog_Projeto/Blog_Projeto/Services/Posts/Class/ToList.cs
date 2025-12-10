using Blog_Projeto.Data;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Posts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Services.Posts.Class
{
    public class ToList : IToList
    {
        private readonly Blog_Context _context;
        public ToList(Blog_Context context)
        {
            _context = context;
        }
        public async Task<List<CompletePost_dto>> tolist(string ordem)
        {
            var item = await _context.DadosPost
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
            switch (ordem)
            {
                case "cres":
                    item = item.OrderBy(i => i.Id).ToList();
                    break;
                case "decres":
                    item = item.OrderByDescending(i => i.Id).ToList();
                    break;
                default:
                    item = item.OrderBy(i => i.Id).ToList();
                    break;
            }
            return item;
        }
    }
}
