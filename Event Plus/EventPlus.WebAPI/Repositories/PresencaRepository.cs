using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepository(EventContext context)
    {
        _context = context;
    }


    /// <summary>
    /// metodo que alterna a situação da presença
    /// </summary>
    /// <param name="Id">id da presença a ser alterado</param>
    public void Atualizar(Guid Id)
    {
        var presencaBuscada = _context.Presencas.Find(Id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método que busca uma preseça por id
    /// </summary>
    /// <param name="id">id da presença buscada</param>
    /// <returns>presença buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdInstituicaoNavigation).FirstOrDefault(p => p.IdPresenca == id)!;
    }

    public void Deletar(Guid id)
    {

        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// cadastra uma presença
    /// </summary>
    /// <param name="presenca">nome da presença cadsatrda</param>
    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges(); 
    }

    /// <summary>
    /// lista todas as presenças cadastradas
    /// </summary>
    /// <returns>as presenças cadastradas</returns>
    public List<Presenca> Listar()
    {
         return _context.Presencas.OrderBy(Presenca => Presenca).ToList();  
    }

    /// <summary>
    /// Método que lista as presenças de um usuario para filtragem
    /// </summary>
    /// <param name="IdUsuario">id usuario para filtragem</param>
    /// <returns>lista de presenças de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e.IdInstituicaoNavigation).Where(p => p.IdUsuario == IdUsuario).ToList();
    }
}
