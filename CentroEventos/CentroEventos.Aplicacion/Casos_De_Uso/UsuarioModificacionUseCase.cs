using System;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;


namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class UsuarioModificacionesUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion,ValidadorUsuario validador)
{
     public void Ejecutar( Usuario usuario,int idUsuario)
    {
       /* if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validador(usuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }*/
        repo.ModificarUsuario(usuario);
    }
}
