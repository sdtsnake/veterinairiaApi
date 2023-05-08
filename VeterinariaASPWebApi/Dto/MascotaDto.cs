using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;


namespace VeterinariaASPWebApi.Dto
{
    public class MascotaDto
    {
        [SwaggerSchema("Identificador único de la mascota.")]
        public int Id { get; set; }

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

        [SwaggerSchema("Usuario propietario de la mascota.")]
        public virtual UsuarioMascotaDto? UsuarioMascotaDto { get; set; }
    }

    public enum Sexo
    {
        Macho,
        Hembra
    }
}