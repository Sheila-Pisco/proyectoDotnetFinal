using System;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    private int _Id_reserva; //gestionado por el repositorio
    private int _Persona_id;
    private int _EventoDeportivoid;
    private DateTime? _FechaAltaReserva;
    private Estado? _EstadoAsistencia;
    public Reserva (int idpersona, int eventoid, DateTime? Fecha, Estado estado){

        // completar aquí las validaciones que aseguren la consistencia de la entidad
        
        this._Persona_id = idpersona;
        this._EventoDeportivoid = eventoid;
        this._FechaAltaReserva = Fecha;
        this._EstadoAsistencia = estado;
    }
    protected Reserva() { } // Constructor vacío (lo utilizará EntityFramework)
    public int Id_reserva
    {
        get { return _Id_reserva; }
    }
    public int Idpersona
    {
        get { return _Persona_id; }
        set { _Persona_id = value; }
    }
    public int IdEven_Dep
    {
        get { return _EventoDeportivoid; }
        set { _EventoDeportivoid = value; }
    }
    public DateTime? Fecha
    {
        get { return _FechaAltaReserva; }
        set { _FechaAltaReserva = value; }
    }
    public Estado? EstadoAsistencia
    {
        get { return _EstadoAsistencia; }
        set { _EstadoAsistencia = value; }
    }
    public override string ToString()
    {
        string aux = "";
        aux += $"Reserva: {this._Id_reserva} , Persona ID: {this._Persona_id} , Evento Deportivo ID: {this._EventoDeportivoid} , Fecha de Alta : {this._FechaAltaReserva} , Estado de Asistencia: {this._EstadoAsistencia}";
        return aux;
    }
}
