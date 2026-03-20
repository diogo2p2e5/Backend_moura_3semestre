using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private readonly IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }


    /// <summary>
    /// EndPoint da API que retorna uma lista de presenças de um usuario específico
    /// </summary>
    /// <param name="idUsuario">id do usuario para a filtragem</param>
    /// <returns>status code 200 e uma lista de presenças</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult BuscarMinhas(Guid idUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que permite a inscrição de um usuário em um evento, criando uma nova presença com a situação de inscrição.
    /// </summary>
    /// <param name="presenca">presenca artribuida a um usuario </param>
    /// <returns>usuario presente em um evento</returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
          var novaPresenca = new Presenca
          {
              Situacao = presenca.Situacao,
              IdEvento = presenca.IdEvento,
              IdUsuario = presenca.IdUsuario,
              
          };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que permite a atualização da situação de uma presença, permitindo que um usuário confirme ou cancele sua presença em um evento.
    /// </summary>
    /// <param name="id">id da presença que sera alterada</param>
    /// <param name="presenca">a presenca atribuida ao usuario alterada</param>
    /// <returns>presenca alterada</returns>
    [HttpPut]
        public IActionResult Atualizar(Guid id, Presenca presenca)
        {
        try
        {
            var presencaAtualizada = new Presenca
            {
                Situacao = presenca.Situacao!
            };


           _presencaRepository.Atualizar(id);
            return StatusCode(204, presencaAtualizada); 
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
