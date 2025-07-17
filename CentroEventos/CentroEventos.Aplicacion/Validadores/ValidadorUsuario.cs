using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario(IRepositorioUsuario repo)
{
    public bool Validador(Usuario usuario, out string mensajeError, bool ok)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
           mensajeError = "El campo Nombre no puede estar vacio. \n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensajeError +="El campo Apellido no puede estar vacio. \n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            mensajeError += "El campo Email no puede estar Vacio. \n";
        }
        else
        {
            if (ok && repo.ExisteEmail(usuario.Email))
            {
                mensajeError += "Email Existente. \n";
            }
        }
        if (string.IsNullOrWhiteSpace(usuario.Contraseña))
        {
            mensajeError += "El campo contraseña no puede estar vacio. \n";
        }
        return mensajeError == "";
    }
}
