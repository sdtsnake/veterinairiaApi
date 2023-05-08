using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using VeterinariaASPWebApi.Models;

namespace VeterinariaASPWebApi.Dto
{
    public class UsuarioMascotaDto
    {
        [SwaggerSchema("Identificador único del usuario.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [SwaggerSchema("Nombre del usuario.")]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        [SwaggerSchema("Apellido del usuario.")]
        public string? Apellido { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [SwaggerSchema("Documento de identificación del usuario.")]
        public int? DocumentoIdentificacion { get; set; }
        
    }
}
