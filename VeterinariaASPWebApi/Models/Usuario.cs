using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaASPWebApi.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? TipoDocumento { get; set; }

    public int? DocumentoIdentificacion { get; set; }

    public string? Estado { get; set; }

    public string? Sexo { get; set; }

    [NotMapped]
    public virtual ICollection<Mascota> Mascota { get; } = new List<Mascota>();
}
