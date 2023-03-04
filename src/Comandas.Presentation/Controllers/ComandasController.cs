using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos.Comanda;
using System.Text.Json;

namespace Comandas.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("RestAPIFurb/[controller]")]
public class ComandasController : ControllerBase
{
    private readonly IServiceManager _service;

    public ComandasController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todas as comandas cadastradas
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ReadComandasDto[]), StatusCodes.Status200OK)]
    public IActionResult GetComandas()
    {
        var comandas = _service.ComandaService.GetAllComandas(false);
        return Ok(comandas);
    }

    /// <summary>
    /// Retorna determinada comanda de acordo com o id informado
    /// </summary>
    [HttpGet("{id:int}", Name = nameof(GetComanda))]
    [ProducesResponseType(typeof(ReadComandaDto), StatusCodes.Status200OK)]
    public IActionResult GetComanda(int id)
    {
        var comanda = _service.ComandaService.GetComanda(id, false);
        return Ok(comanda);
    }

    /// <summary>
    /// Cria uma nova comanda
    /// </summary>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReadComandaDto), StatusCodes.Status201Created)]
    public IActionResult CreateComanda([FromBody] CreateComandaDto comanda)
    {
        var createdComanda = _service.ComandaService.CreateComanda(comanda);
        return CreatedAtRoute(nameof(GetComanda), new { id = createdComanda.Id }, createdComanda);
    }

    //o certo para o especificado no enunciado seria usar patch
    /// <summary>
    /// Atualiza uma determinada comanda
    /// </summary>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReadComandaDto), StatusCodes.Status200OK)]
    public IActionResult UpdateComanda(int id, [FromBody] UpdateComandaDto comanda)
    {
        var updatedComanda = _service.ComandaService.UpdateComanda(id, comanda);

        return Ok(updatedComanda);
    }

    /// <summary>
    /// Remove uma determinada comanda
    /// </summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteComanda(int id)
    {
        _service.ComandaService.DeleteComanda(id, false);
        string retorno = JsonSerializer.Serialize(new { success = new { text = "comanda removida" } });
        return Ok(retorno);
    }
}
