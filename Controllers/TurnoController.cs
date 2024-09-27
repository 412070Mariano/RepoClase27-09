using Microsoft.AspNetCore.Mvc;
using TurnoApi.Models;
using TurnoApi.Services;

namespace TurnoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : Controller
    {
        private readonly ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _turnoService.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            return Ok(_turnoService.Save(turno));
        }
        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] TTurno turno)
        {
            return Ok(_turnoService.Update(turno, id));
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id, [FromQuery] string motivo)
        {
            return Ok(_turnoService.Delete(id, motivo));
        }

        [HttpGet("/Cancelados/{dias}")]

        public async Task<IActionResult> GetCancel(int dias)
        {
            if (dias > 0)
            {
                return Ok(await _turnoService.GetTurnosCancelados(dias));
            }
            else
            {
                return BadRequest("Error, los días estan fuera del rango");
            }
        }

    }
}
