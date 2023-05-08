using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaASPWebApi.Models;

public partial class HistoriasClinica
{
    public int Id { get; set; }

    public int? MascotaId { get; set; }

    public Nullable<DateTime> FechaCreacion { get; set; }

    [NotMapped]
    public virtual ICollection<DetallesHistoriasClinica> DetallesHistoriasClinicas { get; } = new List<DetallesHistoriasClinica>();

    public virtual Mascota? Mascota { get; set; }
}
