using System.Drawing;
using System.Drawing.Imaging;

namespace Blog_Projeto.Services.Profile.ProfExtra
{
    public static class ProfilePics
    {
        private static Color ColorSelect(int random)
        {
            switch (random)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Blue;
                case 3:
                    return Color.Black;
                case 4:
                    return Color.Green;
                default: return Color.Orange;
            }
        }

        public static string NoobPhoto(string Root, string Name)
        {
            //Tamanho da imagem
            string NameConfirm = Name.Substring(0, 1);
            int width = 750;
            int height = 700;

            var config = new Random();
            Color backgroundColor = ColorSelect(config.Next(0, 5));

            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    //Definir o fundo da imagem
                    graphics.Clear(backgroundColor);
                    Font font = new Font("Arial", 300, FontStyle.Regular);
                    Brush textBrush = Brushes.White;
                    SizeF textSize = graphics.MeasureString(NameConfirm, font);
                    float x = (width - textSize.Width) / 2;
                    float y = (height - textSize.Height) / 2;
                    graphics.DrawString(NameConfirm, font, textBrush, x, y);
                }
                //Loca de Save
                string guid = Guid.NewGuid().ToString();
                string CompleteName = "Noob" + guid + ".png";

                var CompleteLocal = Path.Combine(Root, "ProfileImages", "UserPic");

                if (!Directory.Exists(CompleteLocal))
                {
                    Directory.CreateDirectory(CompleteLocal);
                }

                var CompleteFilePath = Path.Combine(CompleteLocal, CompleteName);
                bitmap.Save(CompleteFilePath, ImageFormat.Png);
                var item = "/ProfileImages/" + "UserPic/" + CompleteName;
                return item;
            }
        }

        public static async Task<string> UploadProfile(string Root, IFormFile Foto)
        {
            string guid = Guid.NewGuid().ToString();
            string extensao = Path.GetExtension(Foto.FileName);
            string CompleteName = guid + extensao;

            string CaminhoCompleto = Path.Combine(Root, "ProfileImages", "UserPic");
            if (!Directory.Exists(CaminhoCompleto))
            {
                Directory.CreateDirectory(CaminhoCompleto);
            }

            using (var stream = File.Create(Path.Combine(CaminhoCompleto, CompleteName)))
            {
                await Foto.CopyToAsync(stream);
            }

            string item = "/ProfileImages/" + "UserPic/" + CompleteName;
            return item;
        }

        public static string DeletePhoto(string Root, string Foto)
        {
            if (Root == null || Foto == null)
            {
                return "Erro Null";
            }
            Foto = Foto.Replace("/ProfileImages/UserPic/","");
            string CaminhoCompleto = Path.Combine(Root, "ProfileImages", "UserPic" , Foto);
            if (File.Exists(CaminhoCompleto))
            {
                File.Delete(CaminhoCompleto);
            }
            return "Sucess";
        }
    }
}
