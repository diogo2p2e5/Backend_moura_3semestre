using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository; 
    }


    /// <summary>
    /// Busca um contato por id
    /// </summary>
    /// <param name="id">Id a ser buscado</param>
    /// <returns>O contato buscado</returns>
    [HttpGet]
   public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            throw;
        }
    }

    /// <summary>
    /// lista todos os contatos
    /// </summary>
    /// <returns>retorna os todos os contatos </returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Cria um novo contato
    /// </summary>
    /// <param name="contato">nome do novo contato</param>
    /// <returns>reutorna 201 e cadastra o novo contato</returns>
    [HttpPost]
    public IActionResult Cadastar(ContatoDTO contato)
    {
        try
        {
            var novoContato = new Contato
            {
                Nome = contato.Nome!,
                FormaContato = contato.FormaContato!,
                FotoPerfil = contato.FotoPerfil!,
                IdTipoContato = contato.IdTipoContato
            };

            _contatoRepository.Cadastrar(novoContato);

            return StatusCode(201, novoContato);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="contato"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    IActionResult Atualizar(Guid id, ContatoDTO contato)
    {
        try
        {
            var contatoAtualizado = new Contato
            {
                Nome = contato.Nome!,
                FormaContato = contato.FormaContato!,
                FotoPerfil = contato.FotoPerfil!,
                IdTipoContato = contato.IdTipoContato
            };
            _contatoRepository.Atualizar(id, contatoAtualizado);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




    /// <summary>
    /// Deleta um contato por id
    /// </summary>
    /// <param name="id">id utilizado para deletar um contato</param>
    /// <returns>retorna no content e deleta o contato</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _contatoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
