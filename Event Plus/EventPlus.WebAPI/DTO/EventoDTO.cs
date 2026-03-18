using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "O nome do Evento é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A data do Evento é obrigatória")]
    public DateTime DataEvento { get; set; }

    [Required(ErrorMessage = "A descrição do Evento é obrigatória")]
    public string? Descricao { get; set; }

    public Guid IdTipoEvento { get; set; }

    public Guid IdInstituicao { get; set; }
}
