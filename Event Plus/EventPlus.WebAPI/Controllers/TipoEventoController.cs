using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;

    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }


    /// <summary>
    /// Endpoint da Api que faz a chamada para o metodo de lista os tipos de eventos
    /// </summary>
    /// <returns>Status code 200 e alista de tipos de eventos</returns>
    /// <returns>Status code 200 e alista de tipos de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);  
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de buscar um tipo de evento especifico
    /// </summary>
    /// <param name="id">Id dp tipo evento buscado</param>
    /// <returns>Status code 200 e o tipo de evento buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de cadastrar um tipo de evento
    /// </summary>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>
    /// <returns>Code 201 e o tipo de evento a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {


            var novoTipoEvento = new TipoEvento 
            { 
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            return StatusCode(201, tipoEvento);
        }
        catch (Exception e )
        {

            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de atualizar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo de evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento com os dados atualizados</param>
    /// <returns>Status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEvento tipoEvento)
    {
        try
        {
            var tipoEventoAtualizado = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };


            _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
            return StatusCode(204, tipoEventoAtualizado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo deletar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo de evento a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}
