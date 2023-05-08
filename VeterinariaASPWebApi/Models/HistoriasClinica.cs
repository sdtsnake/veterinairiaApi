using System;
using System.Collections.Generic;

namespace VeterinariaASPWebApi.Models;

public partial class HistoriasClinica
{
    public int Id { get; set; }

    public int? MascotaId { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public virtual ICollection<DetallesHistoriasClinica> DetallesHistoriasClinicas { get; } = new List<DetallesHistoriasClinica>();

    public virtual Mascota? Mascota { get; set; }
}
