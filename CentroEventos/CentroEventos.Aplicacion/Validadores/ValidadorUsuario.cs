using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public bool Validador(Usuario usuario, out string mensajeError, bool ok)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre) && ok)
        {
            mensajeError += "el campo nombre no puede estar vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido)&& ok)
        {
            mensajeError +="El campo apellido no puede estar vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            mensajeError="el campo Email no puede estar Vacio";
        }if (string.IsNullOrWhiteSpace(usuario.Contraseña) && !ok)
        {
            mensajeError += "el campo contraseña no puede estar vacio";
        }
        
        return mensajeError == "";
    }
}
