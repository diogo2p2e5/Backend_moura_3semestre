using ConnectPlus.Models;

namespace ConnectPlus.Interfaces;

public interface ITipoContatoRepository
{
    void Cadastrar(TbTiposContato tipoContato);
    void Deletar(Guid id);

    List<TbTiposContato> Listar();

    TbTiposContato BuscarPorId(Guid id);
    void Atualizar(Guid Id, TbTiposContato tipoContato);
}
