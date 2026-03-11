using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("Presenca")]
public partial class Presenca
{
    [Key]
    [Column("Id_Presenca")]
    public Guid IdPresenca { get; set; }

    public bool Situacao { get; set; }

    [Column("Id_TipoEvento")]
    public Guid? IdTipoEvento { get; set; }

    [Column("Id_Usuario")]
    public Guid? IdUsuario { get; set; }

    [ForeignKey("IdTipoEvento")]
    [InverseProperty("Presencas")]
    public virtual Evento? IdTipoEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Presencas")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
