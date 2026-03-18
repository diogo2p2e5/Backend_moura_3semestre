using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository context)
    {
        _eventoRepository = context;
    }


    /// <summary>
    /// EndPoint da API que faz chamada para o metodo listar os eventos
    /// </summary>
    /// <param name="IdUsuario">Id do usuario para a filtragem</param>
    /// <returns>Lista de eventos filtrados de usuario</returns>
    [HttpGet("Usuario/{IdUsuario}")]
    public IActionResult ListarPorId(Guid IdUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(IdUsuario));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz chamada para o metodo listar os proximos eventos
    /// </summary>
    /// <returns><Status code 200 e uma lista de proximos eventos/returns>
    [HttpGet("ListarProximos")]
    public IActionResult BuscarProximas()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximas());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz chamada para o metodo cadastrar um evento
    /// </summary>
    /// <param name="evento">evento a ser cadastrado</param>
    /// <returns>Code 201 e o evendo cadastrado </returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {


            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                DataEvento = evento.DataEvento!,
                Descricao = evento.Descricao.ToString()!,
                IdTipoEvento = evento.IdTipoEvento,
                IdInstituicao = evento.IdInstituicao
            };

            _eventoRepository.Cadastrar(novoEvento);

            return StatusCode(201, evento);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz chamada para o metodo atualizar um evento
    /// </summary>
    /// <param name="id">id do evento a ser atualizado </param>
    /// <param name="evento">evento com os dados atualizados </param>
    /// <returns>status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, EventoDTO evento)
    {
        try
        {
            var eventoAtualizado = new Evento
            {
                Nome = evento.Nome!,
                DataEvento = evento.DataEvento,
                Descricao = evento.Descricao.ToString()!,
                IdTipoEvento = evento.IdTipoEvento,
                IdInstituicao = evento.IdInstituicao
            };
            _eventoRepository.Atualizar(id, eventoAtualizado);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz chamada para o metodo deletar um evento
    /// </summary>
    /// <param name="id">Id do evento a ser deletado</param>
    /// <returns>status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _eventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

   

}
