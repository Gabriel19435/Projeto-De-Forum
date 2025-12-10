namespace Blog_Projeto.Services.Posts.PostExtra
{
    public static class GerarImg
    {
        public static async Task<string> GerarImagem(IFormFile Foto, string NomeDaPasta, string CaminhoRoot)
        {
            string guid = Guid.NewGuid().ToString();
            string extensao = Path.GetExtension(Foto.FileName);
            string NomeCompleto = guid + extensao;

            string CaminhoCompleto = Path.Combine(CaminhoRoot, NomeDaPasta);
            if (!Directory.Exists(CaminhoCompleto))
            {
                Directory.CreateDirectory(CaminhoCompleto);
            }

            using (var stream = File.Create(Path.Combine(CaminhoCompleto, NomeCompleto)))
            {
                await Foto.CopyToAsync(stream);
            }

            string item = "/" + NomeDaPasta + "/" + NomeCompleto;
            return item;
        }
    }
}
