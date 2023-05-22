using System.ComponentModel.DataAnnotations;

namespace ExemploSession.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }
        public string? Nome { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Forneça um e-mail válido com @")]
        public string? Email { get; set; }
    }
}
