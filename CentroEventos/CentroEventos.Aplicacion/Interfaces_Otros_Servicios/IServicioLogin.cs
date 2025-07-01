using System;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces_Otros_Servicios;

public interface IServicioLogin
{
    public void AlmacenarUsuario(Usuario usuario);
    public Usuario? RecuperarUsuario(string email, string contraseña);
    public void CerrarSesion();
}
