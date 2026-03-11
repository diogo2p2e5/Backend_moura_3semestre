using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _context;

    public InstituicaoRepository(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="instituicao"></param>
    public void Atualizar(Guid Id, Instituicao instituicao)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(Id);

        if (instituicaoBuscada != null)
        {
            instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;

            _context.SaveChanges();

        }
    }

    /// <summary>
    /// buscar instituição por Id
    /// </summary>
    /// <param name="id">id da instituição a ser buscada</param>
    /// <returns>objeto da instituicao com as informações das instituições buscadas </returns>
    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id);
    }

    /// <summary>
    /// cadastra uma instituição
    /// </summary>
    /// <param name="instituicao">instituição a ser cadastrada</param>
    public void Cadastrar(Instituicao instituicao)
    {
       _context.Instituicaos.Add(instituicao);
        _context.SaveChanges(); 
    }

    /// <summary>
    /// deleta uma instituição
    /// </summary>
    /// <param name="id">id da instituição a ser deletada</param>
    public void Deletar(Guid id)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if (instituicaoBuscada != null )
        {
            _context.Instituicaos.Remove(instituicaoBuscada);
            _context.SaveChanges(); 
        }
    }

    public void Listar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(instituicao => instituicao).ToList();  
    }
}
