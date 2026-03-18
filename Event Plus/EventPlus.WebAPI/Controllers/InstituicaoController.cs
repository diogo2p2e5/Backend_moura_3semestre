using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }


    /// <summary>
    /// Endpoint da Api que faz a chamada para o metodo de lista os tipos de Instituições
    /// </summary>
    /// <returns>Status code 200 e alista de tipos de Instituições</returns>
    /// <returns>Status code 200 e alista de tipos de Instituições</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
       
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o método de buscar um tipo de Instituição especifico
    /// </summary>
    /// <param name="id">Id da Instituição buscada</param>
    /// <returns>Status code 200 e a Instituição  buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de cadastrar uma Instituição
    /// </summary>
    /// <param name="instituicao">Instituição a ser cadastrada</param>
    /// <returns>Code 201 e a Instituição a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novaInstituicao = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.Cnpj,
                Endereco = instituicao.Endereco
            };



            _instituicaoRepository.Cadastrar(novaInstituicao);

            return StatusCode(201, instituicao);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de atualizar uma Instituição
    /// </summary>
    /// <param name="id">Id da Instituição a ser atualizada</param>
    /// <param name="instituicao">Instituição com os dados atualizados</param>
    /// <returns>Status code 204 e a Instituição atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Instituicao instituicao)
    {
        try
        {
            var instituicaoAtualizada = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!
            };

            _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
            return StatusCode(204, instituicaoAtualizada);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo deletar uma Instituição
    /// </summary>
    /// <param name="id">Id da Instituição a ser deletada</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


}
