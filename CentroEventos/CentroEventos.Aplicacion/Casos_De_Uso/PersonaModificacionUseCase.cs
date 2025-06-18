using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class PersonaModificacionUseCase(IRepositorioPersona repo, IServicioAutorizacion autorizacion, ValidadorPersona validador)
{
    public void Ejecutar(Persona persona, int idUsuario,bool ok)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.PersonaModificacion))
        {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validador(persona, out string mensajeError,ok))
        {
            throw new ValidacionException(mensajeError);
        }
        repo.ModificarPersona(persona);
    }
}
