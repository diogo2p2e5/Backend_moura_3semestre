using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private readonly ContentSafetyClient _contentSafetyClient;

    private readonly IComentarioEventoRepository _context;

  

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository context)
    {
        _contentSafetyClient = contentSafetyClient;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("O texto a ser moderado não pode ser vazio");
            }

            //Criar objesto de entrada para a moderação
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            //Enviar o texto para moderação (AZURE CONTENT SAFETY)
            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

            //verificar se o texto tem algum tipo de conteúdo impróprio
            bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);


            var novoComentario = new ComentarioEvento
            {
               // IdEvento = comentarioEvento.IdEvento,
                IdUsuario = comentarioEvento.IdUsuario,
                Descricao = comentarioEvento.Descricao,
                Exibe = !temConteudoImproprio,
                DataComentarioEvento = DateTime.Now
            };

            _context.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }


    }
     

}
