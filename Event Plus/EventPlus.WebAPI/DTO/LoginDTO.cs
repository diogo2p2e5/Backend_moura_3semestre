using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O Email do usúario é obrigatoria!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O Senha do usúario é obrigatoria!")]
    public string? Senha { get; set; }
}
