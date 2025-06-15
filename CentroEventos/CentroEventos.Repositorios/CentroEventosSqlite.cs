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

            context.Add(new Persona("22323", "Ari", "Amarilla", "arha@gmail.com", "22535"));

            context.SaveChanges();
        }
    }
}
