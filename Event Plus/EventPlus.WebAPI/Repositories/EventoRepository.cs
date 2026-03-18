using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid Id, Evento evento)
    {
        var EventoBuscado = _context.Eventos.Find(Id);

        if (EventoBuscado != null)
        {
            EventoBuscado.Nome = evento.Nome;

            _context.SaveChanges();
        }
    }

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var EventoBuscado = _context.Eventos.Find(Id);

        if (EventoBuscado != null)
        {
            _context.Eventos.Remove(EventoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Evento> Listar()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Metodo que lista os eventos filtrando por presença do usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuario para filtragem</param>
    /// <returns>Lista de eventos filtrados por usuario</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos.Include(e => e.IdTipoEventoNavigation).Include(e => e.IdInstituicaoNavigation).Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true)).ToList();
    }

    /// <summary>
    /// metodo que lista os eventos que vao acontecer
    /// </summary>
    /// <returns>lista proximos eventos </returns>
    public List<Evento> ListarProximas()
    {
        return _context.Eventos.Include(e => e.IdTipoEventoNavigation).Include(e => e.IdInstituicaoNavigation).Where(e => e.DataEvento >= DateTime.Now).ToList();
    }
}
