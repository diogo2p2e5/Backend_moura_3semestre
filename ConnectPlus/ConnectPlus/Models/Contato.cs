using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
public partial class Contato
{
    [Key]
    [Column("Id_Contato")]
    public Guid IdContato { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    public string FormaContato { get; set; } = null!;

    [Column("foto_perfil")]
    [StringLength(150)]
    public string? FotoPerfil { get; set; }

    [Column("id_TipoContato")]
    public Guid? IdTipoContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("Contatos")]
    public virtual TbTiposContato? IdTipoContatoNavigation { get; set; }
}
