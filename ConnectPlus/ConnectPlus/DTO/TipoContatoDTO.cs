using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    [Required(ErrorMessage = "O Tipo do Contato é obrigatório")]
    public string Titulo { get; set; }
}
