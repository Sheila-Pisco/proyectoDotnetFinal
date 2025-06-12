using System;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class CentroEventoContext:DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }    
}