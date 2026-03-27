using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Cryptography;

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
    [HttpGet("{id}")]
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
    public async Task<IActionResult> Cadastrar([FromForm]ContatoDTO novoContato)
    {
        if (string.IsNullOrEmpty(novoContato.Nome))
            return BadRequest("é obrigatório que o contato tenha nome e tipo de contato");

        Contato contato = new Contato();
        
        if (novoContato.FotoPerfil != null && novoContato.FotoPerfil.Length > 0)
        {
            var extensao = Path.GetExtension(novoContato.FotoPerfil.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/Imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);
            
            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await novoContato.FotoPerfil.CopyToAsync(stream);
            }

            contato.FotoPerfil = nomeArquivo;
            
        }
        contato.Nome = novoContato.Nome;
        contato.FormaContato = novoContato.FormaContato;
        contato.IdTipoContato = novoContato.IdTipoContato;

        try
        {
            _contatoRepository.Cadastrar(contato);
            return StatusCode(201);
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
    public async Task<IActionResult> Put(Guid id, ContatoDTO contato)
    {
        var ContatoBuscado = _contatoRepository.BuscarPorId(id);
        if (ContatoBuscado == null)
            return NotFound("Contato não encontrado");

        if (!string.IsNullOrWhiteSpace(contato.Nome))
            ContatoBuscado.Nome = contato.Nome;

        if (contato.IdTipoContato != null && contato.IdTipoContato != ContatoBuscado.IdTipoContato)
            ContatoBuscado.IdTipoContato = contato.IdTipoContato;

        if (contato.FotoPerfil != null && contato.FotoPerfil.Length != 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Deleta o arquivo antigo
            if (String.IsNullOrEmpty(ContatoBuscado.FotoPerfil))
            {
                var caminhoAntigo = Path.Combine(caminhoPasta, ContatoBuscado.FotoPerfil);

                if (System.IO.File.Exists(caminhoAntigo))
                    System.IO.File.Delete(caminhoAntigo);

            }

            //Salva a nova imagem 
            var extensao = Path.GetExtension(contato.FotoPerfil.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await contato.FotoPerfil.CopyToAsync(stream);
            }

            ContatoBuscado.FotoPerfil = nomeArquivo;
        }



        try
        {
            _contatoRepository.Atualizar(id, ContatoBuscado);
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
    public IActionResult Deletar(Guid id)
    {
        var ContatoBuscado = _contatoRepository.BuscarPorId(id);
        if (ContatoBuscado == null)
            return NotFound("Contato não encontrado!");

        var pastaRelativa = "wwwroot/imagens";
        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);


        if (!string.IsNullOrEmpty(ContatoBuscado.FotoPerfil))
        {
            var caminho = Path.Combine(caminhoPasta, ContatoBuscado.FotoPerfil);

            if (System.IO.File.Exists(caminho))
                System.IO.File.Delete(caminho);
        }


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
