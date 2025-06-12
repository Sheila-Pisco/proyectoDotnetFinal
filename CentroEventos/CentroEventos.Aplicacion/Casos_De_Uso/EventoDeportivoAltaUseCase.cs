using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repoE,IServicioAutorizacion autorizacion,ValidadorEventoDeportivo validador)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
        {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validar(evento, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        repoE.AgregarEvento(evento);
    }
}
