using ConnectPlus.BdContextConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }


    public void Atualizar(Guid Id, Contato contato)
    {
        var ContatoBuscado = _context.Contatos.Find(Id);

        if (ContatoBuscado != null)
        {
            ContatoBuscado.Nome = contato.Nome;

            _context.SaveChanges();
        }
    }

    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var ContatoBuscado = _context.Contatos.Find(Id);

        if (ContatoBuscado != null)
        {
            _context.Contatos.Remove(ContatoBuscado);
            _context.SaveChanges();
        }
    }

    public Contato BuscarPorId(Guid idContato)
    {
        return _context.Contatos.Include(c => c.IdContato).FirstOrDefault(c => c.IdContato == idContato)!;

    }

    public List<Contato> Listar()
    {
        return _context.Contatos.OrderBy(Contato => Contato).ToList();
    }
}
