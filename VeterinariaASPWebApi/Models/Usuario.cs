using System;
using System.Collections.Generic;

namespace VeterinariaASPWebApi.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? TipoDocumento { get; set; }

    public int? DocumentoIdentificacion { get; set; }

    public string? Estado { get; set; }

    public int? Sexo { get; set; }

    public virtual ICollection<Mascota> Mascota { get; } = new List<Mascota>();
}
