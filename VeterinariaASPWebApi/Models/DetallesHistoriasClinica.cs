using System;
using System.Collections.Generic;

namespace VeterinariaASPWebApi.Models;

public partial class DetallesHistoriasClinica
{
    public int Id { get; set; }

    public string? Temperatura { get; set; }

    public float? Peso { get; set; }

    public float? FrecuenciaCardiaca { get; set; }

    public float? FrecuenciaRespiratoria { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Alimentacion { get; set; }

    public string? Habitad { get; set; }

    public string? Observacion { get; set; }

    public int? ColaboradorId { get; set; }

    public int? HistoriaClinicaId { get; set; }

    public virtual Colaborador? Colaborador { get; set; }

    public virtual HistoriasClinica? HistoriaClinica { get; set; }
}
