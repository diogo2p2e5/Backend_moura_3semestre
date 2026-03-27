using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "O nome do usuario é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A forma de contato com o usuario  é obrigatório")]
    public string? FormaContato { get; set; }

    public IFormFile? FotoPerfil { get; set; }

    public Guid IdTipoContato { get; set; }
}
