using System;

namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventoContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creo la base de datos");
        }
    }
}
