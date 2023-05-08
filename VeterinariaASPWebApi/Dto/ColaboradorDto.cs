using Swashbuckle.AspNetCore.Annotations;

namespace VeterinariaASPWebApi.Dto
{
    public class ColaboradorDto : ColaboradorPostDto
    {
        [SwaggerSchema("Identificador único del usuario.")]
        public int Id { get; set; }
    }
}
