using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O nome do usuario é obrigatório")]
    public string? Nome { get; set; }

     [Required(ErrorMessage = "O e-mail do usuario  é obrigatório")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha do usuario é obrigatória")]
    public string? Senha { get; set; }

    public Guid IdTipoUsuario { get; set; }
}
