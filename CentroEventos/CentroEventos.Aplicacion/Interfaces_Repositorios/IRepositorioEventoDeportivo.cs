using System;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces_Repositorios;

public interface IRepositorioEventoDeportivo
{
    public void AgregarEvento(EventoDeportivo evento);
    public void EliminarEvento(int id_evento);
    public void ModificarEvento(EventoDeportivo evento);
    public List<EventoDeportivo> ListarEventos();
    public bool EsResponsableDeEvento(int id_persona);
    public EventoDeportivo ObtenerEvento(int? id_evento);
}
