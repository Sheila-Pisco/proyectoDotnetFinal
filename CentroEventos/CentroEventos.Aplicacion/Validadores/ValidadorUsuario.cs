using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public bool Validador(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            mensajeError += "el campo nombre no puede estar vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensajeError +="El campo apellido no puede estar vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            mensajeError="el campo Email no puede estar Vacio";
        }
        
        return mensajeError == "";
    }
}
