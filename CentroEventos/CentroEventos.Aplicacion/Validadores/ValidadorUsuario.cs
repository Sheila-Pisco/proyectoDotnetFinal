using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario(IRepositorioUsuario repo)
{
    public bool Validador(Usuario usuario, out string mensajeError, bool ok)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre) )
        {
            mensajeError += "el campo nombre no puede estar vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensajeError +="El campo apellido no puede estar vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            mensajeError += "el campo Email no puede estar Vacio";
        }
        else
        {
            if (repo.ExisteEmail(usuario.Email) && ok)
            {
                mensajeError += "Email Existente";
            }
        }
        if (string.IsNullOrWhiteSpace(usuario.Contraseña))
        {
            mensajeError += "el campo contraseña no puede estar vacio";
        }
        
        return mensajeError == "";
    }
}
