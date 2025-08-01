using System;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorEventoDeportivo(IRepositorioPersona repo)
{
    public bool Validar(EventoDeportivo eventoDeportivo, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(eventoDeportivo.Nombre))
        {
            mensajeError += "El nombre no puede estar vacío. \n";
        } 
        if (string.IsNullOrWhiteSpace(eventoDeportivo.Descripcion))
        {
            mensajeError += "La descripción no puede estar vacía. \n";
        }
        if(eventoDeportivo.FechaHoraInicio == DateTime.MinValue || eventoDeportivo.FechaHoraInicio < DateTime.Now)
        {
            mensajeError += "La fecha/hora de inicio no es válida. \n"; 
        }
        if(eventoDeportivo.CupoMaximo <= 0)
        {
            mensajeError += "El cupo máximo no es válido. \n"; 
        }
        if(eventoDeportivo.DuracionHoras <= 0)
        {
            mensajeError += "La duración no es válida. \n";
        }
        if(eventoDeportivo.ResponsableId <= 0 || !repo.ExisteIdPersona(eventoDeportivo.ResponsableId))
        {
            mensajeError += "El Id del responsable no es válido. \n";
        }
        return mensajeError == "";
    }
}
