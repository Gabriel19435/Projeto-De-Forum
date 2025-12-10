using System.ComponentModel.DataAnnotations;

namespace Blog_Projeto.Models.dto
{
    public class DadosUser_dto
    {
        public string? Photo { get; set; }
        public string? Descrition { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PasswordConfirm { get; set; }
    }
}
