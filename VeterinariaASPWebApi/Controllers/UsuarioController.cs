using Microsoft.AspNetCore.Mvc;
using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Services;

namespace VeterinariaASPWebApi.Controllers
{
    [ApiController]
    [Route("/api/veterinaria/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UsuaorioDto> usuarios = _usuarioService.findAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UsuaorioDto usuario = await _usuarioService.findById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usuarioService.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(UsuarioPostDto usuarioPostDto)
        {
            UsuaorioDto usuario = await _usuarioService.save(usuarioPostDto);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UsuaorioDto usuaorioUpdateDto)
        {
            UsuaorioDto usuario = await _usuarioService.update(usuaorioUpdateDto);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


    }
}
