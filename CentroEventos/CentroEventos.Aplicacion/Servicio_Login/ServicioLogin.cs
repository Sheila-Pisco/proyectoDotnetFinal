using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.Servicio_Login;

public class ServicioLogin(IRepositorioUsuario repoU, ValidadorUsuario validador) : IServicioLogin
{
    public Usuario? User { get; private set; }
    public event EventHandler? UsuarioLogeado;
    private void OnUsuarioLogeado()
    {
        UsuarioLogeado?.Invoke(this, EventArgs.Empty);
    }
    public void AlmacenarUsuario(Usuario usuario)
    {
        if (!validador.Validador(usuario, out string mensajeError, true))
        {
            throw new ValidacionException(mensajeError);
        }
        User = usuario;
        OnUsuarioLogeado();
    }
    public Usuario RecuperarUsuario(string email, string contraseña)
    {
        User = new Usuario();
        User = repoU.BuscarUsuarioPorEmailyHash(email, contraseña);
        OnUsuarioLogeado();
        return User;
    }
    
    public void CerrarSesion()
    {
        User = null;
        OnUsuarioLogeado();
    }
}
