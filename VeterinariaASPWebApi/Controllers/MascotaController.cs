using Microsoft.AspNetCore.Mvc;
using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Services;

namespace VeterinariaASPWebApi.Controllers
{
    [ApiController]
    [Route("/api/veterinaria/[controller]")]
    public class MascotaController : ControllerBase
    {
        IMascotaService MascotaServices;

        public MascotaController(IMascotaService services)
        {
            this.MascotaServices = services;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MascotaServices.findAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            MascotaDto mascotaDto = await MascotaServices.findById(id);

            if (mascotaDto == null)
            {
                return NotFound();
            }

            return Ok(mascotaDto);
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                MascotaServices.delete(id);
                return Ok();
            }
            catch (Exception ex) {
                return NotFound(ex);   
            }
        }

        [HttpPost]
        public async Task<IActionResult> save(MascotaPostDto mascotaPostDto)
        {
            MascotaDto mascotaDto = await MascotaServices.save(mascotaPostDto);

            if (mascotaDto == null)
            {
                return NotFound();
            }

            return Ok(mascotaDto);
        }

        [HttpPut]
        public async Task<IActionResult> update(MascotaUpdateDto mascotaUpdateDto)
        {
            MascotaDto mascotaResultado = await MascotaServices.update(mascotaUpdateDto);

            if (mascotaResultado == null)
            {
                return NotFound();
            }

            return Ok(mascotaResultado);
        }



    }


}
