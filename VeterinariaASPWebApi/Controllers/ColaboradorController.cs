using Microsoft.AspNetCore.Mvc;
using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Services;

namespace VeterinariaASPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ColaboradorDto>> GetAll()
        {
            try
            {
                var colaboradores = _colaboradorService.findAll();
                return Ok(colaboradores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorDto>> GetById(int id)
        {
            try
            {
                var colaborador = await _colaboradorService.findById(id);
                if (colaborador == null)
                {
                    return NotFound($"Colaborador con ID {id} no encontrado");
                }

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ColaboradorDto>> Create(ColaboradorPostDto colaboradorPostDto)
        {
            try
            {
                var colaborador = await _colaboradorService.save(colaboradorPostDto);
                return CreatedAtAction(nameof(GetById), new { id = colaborador.Id }, colaborador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ColaboradorDto colaboradorDto)
        {
            try
            {
                if (id != colaboradorDto.Id)
                {
                    return BadRequest("IDs de colaborador no coinciden");
                }

                await _colaboradorService.update(colaboradorDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _colaboradorService.delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

