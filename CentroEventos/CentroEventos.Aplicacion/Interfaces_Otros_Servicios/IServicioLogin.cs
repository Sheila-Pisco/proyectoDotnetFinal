using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Interfaces_Otros_Servicios;

public interface IServicioLogin
{
    public void RegistrarUsuario(Usuario usuario);
    public Usuario RecuperarUsuario(string email, string contraseña);

}
