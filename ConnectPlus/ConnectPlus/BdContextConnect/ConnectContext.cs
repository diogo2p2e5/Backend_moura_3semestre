using System;
using System.Collections.Generic;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.BdContextConnect;

public partial class ConnectContext : DbContext
{
    public ConnectContext()
    {
    }

    public ConnectContext(DbContextOptions<ConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<TbTiposContato> TbTiposContatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConnectPlus;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.IdContato).HasName("PK__Contato__12A7C41EAA8FAB02");

            entity.Property(e => e.IdContato).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoContatoNavigation).WithMany(p => p.Contatos).HasConstraintName("FK__Contato__id_Tipo__60A75C0F");
        });

        modelBuilder.Entity<TbTiposContato>(entity =>
        {
            entity.HasKey(e => e.IdTipoContato).HasName("PK__tb_Tipos__5B2B3BA52AE0E108");

            entity.Property(e => e.IdTipoContato).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
