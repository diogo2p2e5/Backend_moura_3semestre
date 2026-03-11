using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface ITipoUsusarioRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);
    void Deletar(Guid id);

    void Listar(Guid id);
    List<TipoUsuario> Listar();

    TipoUsuario BuscarPorId(Guid id);
    void Atualizar(Guid Id, TipoUsuario tipoUsuario);
}
