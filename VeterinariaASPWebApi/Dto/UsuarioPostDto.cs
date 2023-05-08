using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaASPWebApi.Dto
{
    public class UsuarioPostDto
    {
        [SwaggerSchema("Nombre del usuario.")]
        public string? Nombre { get; set; }

        [SwaggerSchema("Apellido del usuario.")]
        public string? Apellido { get; set; }

        [SwaggerSchema("Tipo de documento de identificación del usuario.")]
        public string? TipoDocumento { get; set; }

        [SwaggerSchema("Número de documento de identificación del usuario.")]
        public int? DocumentoIdentificacion { get; set; }

        [SwaggerSchema("Estado actual del usuario.")]
        public string? Estado { get; set; }

        [EnumDataType(typeof(Sexo))]
        [SwaggerSchema("Sexo del usuario.")]
        public int? Sexo { get; set; }
    }
}
