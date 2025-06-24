using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ReservaModificacionUseCase(IRepositorioReserva repoR, IServicioAutorizacion autorizacion, ValidadorReserva validador)
{
    public void Ejecutar(Reserva reserva,int idUsuario, bool ok)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
        {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validar(reserva, out string mensajeError,ok))
        {
            throw new ValidacionException(mensajeError);
        }
        repoR.ModificarReserva(reserva);
    }
}
