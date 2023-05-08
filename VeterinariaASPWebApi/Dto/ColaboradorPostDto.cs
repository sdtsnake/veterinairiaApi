using Swashbuckle.AspNetCore.Annotations;

namespace VeterinariaASPWebApi.Dto
{
    [SwaggerSchema(Description = "DTO para crear un nuevo Colaborador.")]
    public class ColaboradorPostDto
    {
        [SwaggerSchema(Description = "Nombre del colaborador.")]
        public string? Nombre { get; set; }

        [SwaggerSchema(Description = "Cargo del colaborador.")]
        public string? Cargo { get; set; }

        [SwaggerSchema(Description = "Especialidad del colaborador.")]
        public string? Especialidad { get; set; }

        [SwaggerSchema(Description = "Tipo de documento de identificación del colaborador.")]
        public string? TipoDocumento { get; set; }

        [SwaggerSchema(Description = "Número de documento de identificación del colaborador.")]
        public int? DocumentoIdentificacion { get; set; }

        [SwaggerSchema(Description = "Apellido del colaborador.")]
        public string? Apellido { get; set; }
    }
}
