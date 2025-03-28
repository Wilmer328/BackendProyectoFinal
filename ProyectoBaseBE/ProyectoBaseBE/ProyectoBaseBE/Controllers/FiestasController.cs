using Microsoft.AspNetCore.Mvc;
using ProyectoBaseBE.Models;
using ProyectoBaseBE.Services;

namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class FiestasController : ControllerBase
{
    private readonly FiestaService _fiestaService;

    public FiestasController(FiestaService fiestaService)
    {
        _fiestaService = fiestaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Fiestas>>> ObtenerFiestas()
    {
        var fiestas = await _fiestaService.ObtenerFiestas();
        return Ok(fiestas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fiestas>> ObtenerFiestaPorId(Guid id)
    {
        var fiesta = await _fiestaService.ObtenerFiestasPorId(id);
        if (fiesta == null) return NotFound("Fiesta no encontrado");

        return Ok(fiesta);
    }

    [HttpPost]
    public async Task<ActionResult> CrearFiesta([FromBody] Fiestas fiestas)
    {
        if (fiestas == null)
        {
            return BadRequest("Datos de fiesta vienen vacios");
        }
        var nuevaFiesta = await _fiestaService.CrearFiestas(fiestas);
        return Ok(nuevaFiesta);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarFiesta(Guid id, [FromBody] Fiestas fiestaActualizada)
    {
        if (fiestaActualizada == null)
        {
            return BadRequest("Datos de fiesta vienen vacios");
        }

        var response = await _fiestaService.ActualizarFiestas(id, fiestaActualizada);

        if (response == false)
        {
            return NotFound("Fiesta no encontrado en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarFiesta(Guid id)
    {
        var response = await _fiestaService.EliminarFiestas(id);
        if (response == false)
        {
            return NotFound("Fiesta no encontrado en base de datos");
        }
        return NoContent();
    }

}