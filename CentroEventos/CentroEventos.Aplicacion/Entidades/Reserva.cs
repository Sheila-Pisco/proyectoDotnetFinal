using System;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; private set; } //autoincremental y unico
    public int Persona_id { get; set; } //responsable de la reserva
    public int EventoDeportivo_id { get; set; } //evento asignado a la reserva
    public DateTime? FechaAltaReserva { get; set; } //fecha en la que se realizo
    public Estado? EstadoAsistencia { get; set; } = Estado.Pendiente;//asistencia (Pendiente/Presente/Ausente)
    public Reserva (int idpersona, int eventoid, DateTime? Fecha, Estado estado)
    {
        this.Persona_id = idpersona;
        this.EventoDeportivo_id = eventoid;
        this.FechaAltaReserva = Fecha;
        this.EstadoAsistencia = estado;
    }
    public Reserva() { } // Constructor vacío (lo utilizará EntityFramework)
    public override string ToString()
    {
        string aux = "";
        aux += $"Reserva: {Id} , Persona ID: {Persona_id} , Evento Deportivo ID: {EventoDeportivo_id} , Fecha de Alta : {FechaAltaReserva} , Estado de Asistencia: {EstadoAsistencia}";
        return aux;
    }
}
