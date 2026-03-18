using _20231900201_AslheyPineda_WebApiPacientesExamen.DTOs;
using _20231900201_AslheyPineda_WebApiPacientesExamen.Services;
using Microsoft.AspNetCore.Mvc;

namespace _20231900201_AslheyPineda_WebApiPacientesExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteAppService _service;

        public PacientesController(PacienteAppService service)
        {
            _service = service;
        }

        // GET api/pacientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _service.GetAllAsync();
            return Ok(pacientes);
        }

        // GET api/pacientes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _service.GetByIdAsync(id);
            if (paciente == null)
                return NotFound(new { mensaje = "Paciente no encontrado." });
            return Ok(paciente);
        }

        // POST api/pacientes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearPacienteDTO dto)
        {
            try
            {
                var creado = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT api/pacientes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarPacienteDTO dto)
        {
            try
            {
                var actualizado = await _service.UpdateAsync(id, dto);
                if (actualizado == null)
                    return NotFound(new { mensaje = "Paciente no encontrado." });
                return Ok(actualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE api/pacientes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = "Paciente no encontrado." });
            return Ok(new { mensaje = "Paciente inactivado correctamente." });
        }
    }
}