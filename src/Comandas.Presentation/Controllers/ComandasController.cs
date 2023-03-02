using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System.Net;

namespace Comandas.Presentation.Controllers;

[Route("RestAPIFurb/[controller]")]
[ApiController]
public class ComandasController : ControllerBase
{
    private readonly IServiceManager _service;

    public ComandasController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetComandas()
    {
        try
        {
            var comandas = _service.ComandaService.GetAllComandas(false);
            return Ok(comandas);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetComandasById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateComanda([FromBody] CreateComandaDto comanda)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateComanda(int id, [FromBody] CreateComandaDto comanda)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComanda(int id)
    {
        return Ok();
    }
}
