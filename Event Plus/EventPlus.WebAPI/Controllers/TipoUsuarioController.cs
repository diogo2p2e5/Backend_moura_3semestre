using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsusarioRepository _tipoUsusarioRepository;

    public TipoUsuarioController(ITipoUsusarioRepository tipoUsusarioRepository)
    {
       _tipoUsusarioRepository = tipoUsusarioRepository;
    }

    /// <summary>
    /// Endpoint da Api que faz a chamada para o metodo de lista os tipos de Usuarios
    /// </summary>
    /// <returns>Status code 200 e alista de tipos de Usuarios</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoUsusarioRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o método de buscar um tipo de Usuario especifico
    /// </summary>
    /// <param name="id">Id dp tipo usuario buscado</param>
    /// <returns>Status code 200 e o tipo de usuario buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoUsusarioRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }

       
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de cadastrar um tipo de Usuario
    /// </summary>
    /// <param name="tipoUsuario">tipo de usuario a ser cadastrado</param>
    /// <returns>Code 201 e o tipo de usuario a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var novoTipoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsusarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201, tipoUsuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de atualizar um tipo de Usuario
    /// </summary>
    /// <param name="id">Id do tipo de Usuario a ser atualizado</param>
    /// <param name="tipoUsuario">tipo de usuario com os dados atualizados</param>
    /// <returns>Status code 204 e o tipo de usuario atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        try
        {
            var tipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsusarioRepository.Atualizar(id, tipoUsuarioAtualizado);
            return StatusCode(204, tipoUsuarioAtualizado);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo deletar um tipo de Usuario
    /// </summary>
    /// <param name="id">Id do tipo de Usuario a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoUsusarioRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);

        }
    }
}
