using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaASPWebApi.Dto
{
    public class MascotaPostDto
    {
        [Required]
        [MaxLength(50)]
        [SwaggerSchema("Nombre de la mascota.")]
        public string? Nombre { get; set; }

        [MaxLength(50)]
        [SwaggerSchema("Raza de la mascota.")]
        public string? Raza { get; set; }

        [EnumDataType(typeof(Sexo))]
        [SwaggerSchema("Sexo de la mascota.")]
        public string? Sexo { get; set; }

        [Required]
        [SwaggerSchema("Identificador del usuario propietario de la mascota.")]
        public int UsuarioId { get; set; }
    }


}
