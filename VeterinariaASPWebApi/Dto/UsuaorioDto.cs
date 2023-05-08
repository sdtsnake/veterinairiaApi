using Swashbuckle.AspNetCore.Annotations;

namespace VeterinariaASPWebApi.Dto
{
    public class UsuaorioDto : UsuarioPostDto
    {
        [SwaggerSchema("Identificador único del usuario.")]
        public int Id { get; set; }
    }
}
