using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Projeto.Models
{
    public class DadosPost
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey("UserId")]
        public int PostOwner { get; set; }

        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Descriçao { get; set; }
        public string? Foto { get; set; }
    }
}
