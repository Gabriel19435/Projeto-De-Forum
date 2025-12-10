using Blog_Projeto.Data;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Posts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Services.Posts.Class
{
    public class FindCompletePost : IFindCompletePost
    {
        private readonly Blog_Context _context;
        public FindCompletePost(Blog_Context context)
        {
            _context = context;
        }
        public async Task<CompletePost_dto> findcomplete(int id)
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
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }
    }
}
