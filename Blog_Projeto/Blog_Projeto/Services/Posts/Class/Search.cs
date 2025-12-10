using Blog_Projeto.Data;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Posts.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Blog_Projeto.Services.Posts.Class
{
    public class Search : ISearch
    {
        private readonly Blog_Context _context;
        public Search(Blog_Context context)
        {
            _context = context;
        }
        public async Task<(List<CompletePost_dto>,bool)> search(string Procura , string Type)
        {
            bool active;
            var item = _context.DadosPost.AsNoTracking()
                .Join(_context.DadosUser.AsNoTracking(),
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
                    });

            switch (Type)
            {
                case "Post":
                    item = item.Where(x => x.Titulo.Contains(Procura));
                    active = true;
                    break;
                case "User":
                    item = item = _context.DadosUser.AsNoTracking()
                        .GroupJoin(_context.DadosPost.AsNoTracking(),
                            user => user.Id,
                            post => post.PostOwner,
                            (user, posts) => new CompletePost_dto
                            {
                                UserPhoto = user.Photo,
                                UserName = user.Name,
                                PostOwner = user.Id
                            }).Where(x => x.UserName.Contains(Procura));
                    active = false;
                    if (Procura == "all: users")
                    {
                        item = item = _context.DadosUser.AsNoTracking()
                             .GroupJoin(_context.DadosPost.AsNoTracking(),
                                 user => user.Id,
                                 posts => posts.PostOwner,
                                 (user, posts) => new CompletePost_dto
                                 {
                                     UserPhoto = user.Photo,
                                     UserName = user.Name,
                                     PostOwner = user.Id
                                 });
                        active = false;
                    }
                    break;
                default:
                    item = item.Where(x => x.Titulo.Contains(Procura));
                    active = true;
                    break;
            }

            return (await item.ToListAsync(), active);
        }
    }
}
