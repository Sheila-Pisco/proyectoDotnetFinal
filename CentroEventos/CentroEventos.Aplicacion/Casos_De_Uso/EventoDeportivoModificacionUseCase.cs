using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

//Implementación correcta con validaciones: 
public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repoE, IServicioAutorizacion autorizacion, ValidadorEventoDeportivo validador)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
        {
            throw new FalloAutorizacionException();
        }
        if (validador.Validar(evento, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        repoE.ModificarEvento(evento);
    }
}

/*Implementación para pruebas rápidas:
public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repoE)
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {
        repoE.ModificarEvento(evento);
    }
}*/
