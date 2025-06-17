using System;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class UsuarioAltaUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion, ValidadorUsuario validador)
{
     public void Ejecutar(Usuario usuario, int IdUsuario)
     {
         if (!autorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioAlta))
         {
             throw new FalloAutorizacionException();  
         }
         if (!validador.Validador(usuario, out string mensajeError))
         {
             throw new ValidacionException(mensajeError);
         }
         repo.AgregarUsuario(usuario);
     }
}
