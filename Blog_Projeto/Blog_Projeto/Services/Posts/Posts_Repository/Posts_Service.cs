using Blog_Projeto.Models;
using Blog_Projeto.Models.dto;
using Blog_Projeto.Services.Posts.Interface;
using Blog_Projeto.Services.Profile.ProfExtra;

namespace Blog_Projeto.Services.Posts.Posts_Repository
{
    public class Posts_Service
    {
        private readonly IToList _Read;
        private readonly IDeletePost _DeletePost;
        private readonly ICreatePost _CreatePost;
        private readonly IEdit _Edit;
        private readonly IFind _Find;
        private readonly IFindCompletePost _FindCompletePost;
        private readonly ISearch _Search;
        public Posts_Service(IToList read, IDeletePost DeletePost, ICreatePost CreatePost, IEdit Edit, IFind Find, ISearch Search, IFindCompletePost FindCompletePost)
        {
            _Read = read;
            _DeletePost = DeletePost;            
            _CreatePost = CreatePost;
            _Edit = Edit;
            _Find = Find;
            _FindCompletePost = FindCompletePost;
            _Search = Search;
        }
        public async Task<List<CompletePost_dto>> ToList(string ordem)
        {
            return await _Read.tolist(ordem);
        }

        public async Task<CompletePost_dto> FindCompletePost(int id)
        {
            return await _FindCompletePost.findcomplete(id);
        }

        public async Task<DadosPost> Find(int id)
        {
            return await _Find.find(id);
        }

        public async Task<bool> DeletePost(int id, int UserId)
        {
            return await _DeletePost.Deletar(id, UserId);
        }        

        public async Task<List<CompletePost_dto>> CriarPost(IFormFile Foto, DadosPost post, int UserId)
        {
            return await _CreatePost.Criarpost(Foto, post.Titulo, post.Descriçao, UserId);
        }

        public async Task<ResponseModel<DadosUser>> Editar(int id, DadosPost User, IFormFile Foto, string delete)
        {
            return await _Edit.Editar(id, User.Titulo, User.Descriçao, Foto, delete);
        }

        public async Task<(List<CompletePost_dto>, bool)> Search(string Procura, string Type)
        {
            return await _Search.search(Procura, Type);
        }
    }
}
