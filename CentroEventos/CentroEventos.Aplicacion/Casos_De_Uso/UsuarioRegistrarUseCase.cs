using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class UsuarioRegistrarUseCase(ValidadorUsuario validador, IRepositorioUsuario repo)
{
    public void Ejecutar(Usuario usuario,bool ok)
    {
        if (!validador.Validador(usuario, out string mensajeError,ok))
        {
            throw new ValidacionException(mensajeError);
        }
        repo.RegistrarUsuario(usuario);
     }
}
