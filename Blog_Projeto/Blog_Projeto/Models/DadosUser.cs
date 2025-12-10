namespace Blog_Projeto.Models
{
    public class DadosUser
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }

        public string? Photo { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Descrition { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] PasswordKey { get; set; }
    }
}
