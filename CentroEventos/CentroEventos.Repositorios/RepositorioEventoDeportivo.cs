using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    protected readonly CentroEventoContext context =  new CentroEventoContext();
    public void AgregarEvento(EventoDeportivo evento)
    {
        context.EventosDeportivos.Add(evento);
        context.SaveChanges();
        Console.WriteLine($"Evento {evento.Id} agregado con éxito.");
    }
    public void EliminarEvento(int id_evento)
    {
        var eventoBorrar = context.EventosDeportivos.Where(ed => ed.Id == id_evento).SingleOrDefault();
        if (eventoBorrar == null)
        {
            throw new EntidadNotFoundException();
        }
        context.Remove(eventoBorrar); // se borra realmente con context.saveChanges();
        context.SaveChanges();
        Console.WriteLine($"Evento {id_evento} borrado con éxito.");
    }
    public bool EsResponsableDeEvento(int id_persona)
    {
        bool responsable = false; 
        var eventoBorrar = context.EventosDeportivos.Where(ed => ed.ResponsableId == id_persona).SingleOrDefault();
        if (eventoBorrar != null)
        {
            responsable = true;
        }
        return responsable;
    }
    public List<EventoDeportivo> ListarEventos()
    {
        var lista_eventos = context.EventosDeportivos.ToList();
        return lista_eventos;
    }
    public void ModificarEvento(EventoDeportivo evento)
    {
        throw new NotImplementedException();
    }
}
