using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("ComentarioEvento")]
public partial class ComentarioEvento
{
    [Key]
    [Column("Id_ComentarEvento")]
    public Guid IdComentarEvento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataComentarioEvento { get; set; }

    [StringLength(200)]
    public string Descricao { get; set; } = null!;

    public bool Exibe { get; set; }

    [Column("Id_Evento")]
    public Guid? IdEvento { get; set; }

    [Column("Id_Usuario")]
    public Guid? IdUsuario { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("ComentarioEventos")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
