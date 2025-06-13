using System;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; private set; } //gestionado por el repositorio
    public int Persona_id { get; private set; }
    public int EventoDeportivo_id { get; private set; }
    public DateTime? FechaAltaReserva { get; private set; }
    public Estado? EstadoAsistencia { get; private set; }
    public Reserva (int idpersona, int eventoid, DateTime? Fecha, Estado estado){

        // completar aquí las validaciones que aseguren la consistencia de la entidad
        
        this.Persona_id = idpersona;
        this.EventoDeportivo_id = eventoid;
        this.FechaAltaReserva = Fecha;
        this.EstadoAsistencia = estado;
    }
    protected Reserva() { } // Constructor vacío (lo utilizará EntityFramework)
    public override string ToString()
    {
        string aux = "";
        aux += $"Reserva: {Id} , Persona ID: {Persona_id} , Evento Deportivo ID: {EventoDeportivo_id} , Fecha de Alta : {FechaAltaReserva} , Estado de Asistencia: {EstadoAsistencia}";
        return aux;
    }
}
