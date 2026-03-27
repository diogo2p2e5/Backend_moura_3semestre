using ConnectPlus.Models;

namespace ConnectPlus.Interfaces;

public interface IContatoRepository
{
    void Cadastrar(Contato contato);

    void Deletar(Guid guid);

    Contato BuscarPorId(Guid idContato);

    List<Contato> Listar();

    void Atualizar(Guid Id, Contato contato);
}
