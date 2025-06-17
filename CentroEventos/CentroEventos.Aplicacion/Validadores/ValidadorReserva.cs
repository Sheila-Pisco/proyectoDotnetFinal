using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorReserva (IRepositorioReserva repoReserva, IRepositorioPersona repoPersona)
{
    public bool Validar(Reserva reserva, out string mensajeError){

        mensajeError = "";

        if (!repoPersona.ExisteIdPersona(reserva.Persona_id))
        {
            mensajeError += "No existe persona con id";
        }
        if (!repoReserva.ExisteResposable(reserva.Persona_id))
        {
            mensajeError += "La persona no reservo";
        }
        if (repoReserva.ExisteReserva(reserva.Persona_id, reserva.EventoDeportivo_id))
        {
            mensajeError += "La persona ingresada ya posee una reserva para este evento";
        }
        if (!repoReserva.ExisteCupo(reserva.EventoDeportivo_id))
        {
            mensajeError += "No hay cupo en este evento";
        }
        return (mensajeError == "");
    }
}
