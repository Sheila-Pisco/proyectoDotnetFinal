using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventoContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creo la base de datos");

            context.Add(new EventoDeportivo("Aerobicos", "Movete", new DateTime(2025, 1, 1), 1.5, 15, 2));
            context.Add(new Usuario("Juan", "Perez", "juanP@gmail", "123456", new List<Permiso> { Permiso.EventoAlta }));
            context.Add(new Reserva(3, 1, new DateTime(2025, 1, 1), Estado.Pendiente));

            context.SaveChanges();
        }
    }
}
