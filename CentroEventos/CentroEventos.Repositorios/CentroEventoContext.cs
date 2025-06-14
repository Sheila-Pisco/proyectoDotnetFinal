using System;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class CentroEventoContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }
    //La propiedad journal_mode se utiliza en una base de datos SQLite para especificar el modo de registro de transacciones que se utilizará.
    //Al utilizar el modo DELETE en SQLite, los cambios realizados se reflejan inmediatamente en la base de datos principal.
    public CentroEventoContext()
    {
        this.Database.EnsureCreated();
        var connection = this.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    }
        
}