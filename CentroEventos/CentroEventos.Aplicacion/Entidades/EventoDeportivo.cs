using System;

namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int Id { get; private set; } // único, debe ser autoincremental gestionado por el repositorio) 
    public string? Nombre{ get; set; } // ej: "Clase de Spinning Avanzado", "Partido final de Vóley"
    public string? Descripcion{ get; set; }
    public DateTime FechaHoraInicio{ get; set; } //  DateTime - Fecha y hora exactas de inicio del evento
    public double DuracionHoras{ get; set; } // Duración del evento en horas, ej: 1.5 para una hora y media
    public int CupoMaximo{ get; set; } // Cantidad máxima de participantes permitidos
    public int ResponsableId{ get; set; } // Id de la Persona a cargo del evento
    public EventoDeportivo(string nombre, string descripcion, DateTime fecha_hora, double duracion, int cupo_max, int id_responsable)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede ser nulo ni estar vacío");
        }
        if (string.IsNullOrEmpty(descripcion))
        {
            throw new ArgumentException("La descripción no puede estar vacía.");
        }
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.FechaHoraInicio = fecha_hora;
        this.DuracionHoras = duracion;
        this.CupoMaximo = cupo_max;
        this.ResponsableId = id_responsable;
    }
    public EventoDeportivo() { } //Constructor vacío, lo utilizará Entity Framework. 
    public override string ToString(){
        return $" Evento {Id}, nombre: '{Nombre}': \n Descripcion: {Descripcion} \n Fecha y Hora: {FechaHoraInicio.ToString()} , duración: {DuracionHoras}hs , cupo máximo: {CupoMaximo} , ID del responsable: {ResponsableId} ";
    }
}
