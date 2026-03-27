using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private readonly ITipoContatoRepository _tipoContatoRepository;

    public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
    {
        _tipoContatoRepository = tipoContatoRepository;
    }


    /// <summary>
    /// Busca um contato por id
    /// </summary>
    /// <param name="id">Id a ser buscado</param>
    /// <returns>O tipo contato buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoContatoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            throw;
        }
    }

    /// <summary>
    /// lista todos os tipos de contatos
    /// </summary>
    /// <returns>retorna os todos os tipos de contato </returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoContatoRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Cria um novo tipo contato
    /// </summary>
    /// <param name="tipoContato">titulo do novo tipo contato</param>
    /// <returns>reutorna 201 e cadastra o novo tipo de contato</returns>
    [HttpPost]
    public IActionResult Cadastar(TipoContatoDTO tipoContato)
    {
        try
        {
            var novoTipoContato = new TbTiposContato
            {
                Titulo = tipoContato.Titulo,
            };

            _tipoContatoRepository.Cadastrar(novoTipoContato);

            return StatusCode(201, novoTipoContato);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// atualiza um tipo contato por id
    /// </summary>
    /// <param name="id">id do tipo de contato a ser alterado</param>
    /// <param name="tipoContato">titulo alterado do tipo de contato</param>
    /// <returns>retorna o tipo de contato atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoContatoDTO tipoContato)
    {
        try
        {
            var TipocontatoAtualizado = new TbTiposContato
            {
                Titulo = tipoContato.Titulo,
            };
            _tipoContatoRepository.Atualizar(id, TipocontatoAtualizado);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




    /// <summary>
    /// Deleta um  tipo de contato por id
    /// </summary>
    /// <param name="id">id utilizado para deletar um tipo de contato</param>
    /// <returns>retorna no content e deleta o tipo de contato</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoContatoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
