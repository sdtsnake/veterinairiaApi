using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaASPWebApi.Models;

public partial class VeterinariaContext : DbContext
{
    public VeterinariaContext()
    {
    }

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colaborador> Colaboradores { get; set; }

    public virtual DbSet<DetallesHistoriasClinica> DetallesHistoriasClinicas { get; set; }

    public virtual DbSet<HistoriasClinica> HistoriasClinicas { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
}
