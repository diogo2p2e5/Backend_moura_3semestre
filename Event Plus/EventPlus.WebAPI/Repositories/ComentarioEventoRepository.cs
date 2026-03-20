using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{

    private readonly EventContext _context;

    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }


    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        throw new NotImplementedException();
        // return _context.ComentarioEventos.Include(u => u.IdUsuarioNavigation).FirstOrDefault(u => u.IdUsuario == IdUsuario && u.IdEvento == IdEvento)!;

    }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }

    public void Deletar(Guid IdComentarioEvento)
    {
        var comentarioBuscado = _context.ComentarioEventos.Find(IdComentarioEvento);

        if (comentarioBuscado != null)
        {
            _context.ComentarioEventos.Remove(comentarioBuscado);
            _context.SaveChanges();
        }
    }

    public List<ComentarioEvento> List(Guid IdEvento)
    {
        throw new NotImplementedException();
        //return _context.ComentarioEventos.Include(u => u.IdUsuarioNavigation).Where(c => c.IdEvento == IdEvento).ToList();
    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        throw new NotImplementedException();
        // return _context.ComentarioEventos.Where(c => c.IdEvento == IdEvento && c.Exibe == true ).Include(c => c.IdUsuarioNavigation).ToList();
    }
}
