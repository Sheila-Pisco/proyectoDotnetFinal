using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.Servicio_Login;

public class ServicioLogin(IRepositorioUsuario repoU, ValidadorUsuario validador) : IServicioLogin
{
    public Usuario User { get; set; } = new Usuario();
    public void AlmacenarUsuario(Usuario usuario)
    {
        if (!validador.Validador(usuario, out string mensajeError, true))
        {
            throw new ValidacionException(mensajeError);
        }
        User = usuario;
    }
    public Usuario RecuperarUsuario(string email, string contraseña)
    {
        User.Email = email;
        User.Contraseña = contraseña;
        if (!validador.Validador(User, out string mensajeError, false))
        {
            throw new ValidacionException(mensajeError);
        }
        User = repoU.BuscarUsuarioPorEmailyHash(email, contraseña);
        return User;
    }
    /*
    public void Salir()
    {
        User = null;
    }
    */
}
