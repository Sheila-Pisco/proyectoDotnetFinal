using System;
using System.Security.Cryptography;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
namespace CentroEventos.Aplicacion.Servicio_Login;

public class ServicioLogin(IRepositorioUsuario repoU) : IServicioLogin
{
    public Usuario User { get; set; } = new Usuario(); 
    public void AlmacenarUsuario(Usuario usuario)
    {
        User = usuario;
    }
    public Usuario RecuperarUsuario(string email, string contraseña)
    {
        //chequear que mail sea valido con try catch y la contraseña hacerle un hash 
        User = repoU.BuscarUsuarioPorEmailyHash(email, contraseña);
        return User;
    }
}
