using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class PersonaAltaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion autorizacion, ValidadorPersona validador)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
        {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validador(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        repoPersona.AgregarPersona(persona);
    }
}
