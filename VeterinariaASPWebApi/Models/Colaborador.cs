using System;
using System.Collections.Generic;

namespace VeterinariaASPWebApi.Models;

public partial class Colaborador
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public string? Especialidad { get; set; }

    public string? TipoDocumento { get; set; }

    public int? DocumentoIdentificacion { get; set; }

    public string? Apellido { get; set; }

    public virtual ICollection<DetallesHistoriasClinica> DetallesHistoriasClinicas { get; } = new List<DetallesHistoriasClinica>();
}
