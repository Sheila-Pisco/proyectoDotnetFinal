using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas; 

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ReservaAltaUseCase(IRepositorioReserva repoR, IServicioAutorizacion autorizacion, ValidadorReserva validacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario, bool ok)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
        {
            throw new FalloAutorizacionException();
        }
        if (!validacion.Validar(reserva, out string error, ok))
        {
            throw new Exception("Error al subir la reserva: "+ error);
        }
        Console.WriteLine("Se validó la reserva, procede el alta.");
        repoR.AgregarReserva(reserva);
    }
}
