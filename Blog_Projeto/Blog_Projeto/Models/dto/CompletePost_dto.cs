namespace Blog_Projeto.Models.dto
{
    public class CompletePost_dto
    {
        public string? UserPhoto { get; set; }
        public string? UserName { get; set; }
        public int PostOwner { get; set; }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string? Titulo { get; set; }
        public string? Descriçao { get; set; }
        public string? Foto { get; set; }
    }
}
