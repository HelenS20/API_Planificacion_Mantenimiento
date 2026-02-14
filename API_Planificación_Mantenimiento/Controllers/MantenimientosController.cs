using API_Planificación_Mantenimiento.Context;
using API_Planificación_Mantenimiento.Models.Entities;
using API_Planificación_Mantenimiento.Models.Request;
using API_Planificación_Mantenimiento.Models.Responses;
using API_Planificación_Mantenimiento.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API_Planificación_Mantenimiento.Controllers
{
    [ApiController]
    [Route("api/mantenimientos")]
    public class MantenimientosController : ControllerBase
    {
        private readonly IMantenimientoService _service;
        private readonly AppDbContext _context;

        public MantenimientosController(
            IMantenimientoService service,
            AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MantenimientoRequest request)
        {
            if (request.Cada <= 0)
                return BadRequest("El valor 'cada' debe ser mayor a 0.");

            var ciclos = _service.CalcularMantenimientos(
                request.CicloInicio,
                request.CicloFin,
                request.TipoRecurrencia,
                request.Cada
            );

            var entidad = new Mantenimiento
            {
                CicloInicio = request.CicloInicio,
                CicloFin = request.CicloFin,
                TipoRecurrencia = request.TipoRecurrencia,
                Cada = request.Cada,
                Resultado = JsonSerializer.Serialize(ciclos),
                CreatedAt = DateTime.UtcNow
            };

            _context.Mantenimientos.Add(entidad);
            await _context.SaveChangesAsync();

            return Ok(new MantenimientoResponse
            {
                CiclosMantenimiento = ciclos
            });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerHistorial()
        {
            var historial = await _context.Mantenimientos.ToListAsync();
            return Ok(historial);
        }
    }

}
