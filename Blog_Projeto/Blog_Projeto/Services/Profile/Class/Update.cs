using Blog_Projeto.Data;
using Blog_Projeto.Models;
using Blog_Projeto.Services.Profile.ProfExtra;
using Site_Blog.Service.Profile.Interface;

namespace Site_Blog.Service.Profile.Class
{
    public class Update : IUpdate
    {
        private readonly Blog_Context _context;
        private string Root;
        public Update(Blog_Context context, IWebHostEnvironment web)
        {
            _context = context;
            Root = web.WebRootPath;
        }

        public async Task<ResponseModel<DadosUser>> update(DadosUser User, IFormFile Photo, int id, string deleted)
        {
            ResponseModel<DadosUser> Response = new ResponseModel<DadosUser>();
            //ToModel
            var item = _context.DadosUser.Find(id);
            string MaybeNoob = item.Photo.Replace("/ProfileImages/UserPic/", "").Substring(0, 4);

            if (User.Name != null)
            {
                if (User.Name.Length < 4 || User.Name.Length > 30)
                {
                    Response.ViewMessage = "The Name Must Have 10 Words Atleast";
                    return Response;
                }
                item.Name = User.Name;
            }
            if (MaybeNoob == "Noob" || deleted == "deleted")
            {
                ProfilePics.DeletePhoto(Root, item.Photo);
                string _Photo = ProfilePics.NoobPhoto(Root, item.Name);
                item.Photo = _Photo;
            }
            if (Photo != null)
            {
                ProfilePics.DeletePhoto(Root, item.Photo);
                string _Photo = await ProfilePics.UploadProfile(Root, Photo);
                item.Photo = _Photo;
            }
            if (User.Descrition != null)
            {
                if (User.Descrition.Length < 4 || User.Descrition.Length > 50)
                {
                    Response.ViewMessage = "The Name Must Have 90 Words Atleast";
                    return Response;
                }
                item.Descrition = User.Descrition;
            }
            if (User.Descrition == null)
            {
                item.Descrition = "Null";
            }
            _context.DadosUser.Update(item);
            await _context.SaveChangesAsync();

            Response.Erro = false;
            return Response;
        }
    }
}
