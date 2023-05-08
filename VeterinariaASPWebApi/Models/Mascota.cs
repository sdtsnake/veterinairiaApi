using System;
using System.Collections.Generic;

namespace VeterinariaASPWebApi.Models;

public partial class Mascota
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Raza { get; set; }

    public int? UsuarioId { get; set; }

    public string? Sexo { get; set; }

    public virtual ICollection<HistoriasClinica> HistoriasClinicas { get; } = new List<HistoriasClinica>();

    public virtual Usuario? Usuario { get; set; }
}
