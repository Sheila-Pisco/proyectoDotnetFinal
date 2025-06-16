using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    protected readonly CentroEventoContext _context;
    public RepositorioUsuario(CentroEventoContext context)
    {
        _context = context;
    }
    public void AgregarUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        Console.WriteLine("Usuario Agregado con Exito");
    }

    public void EliminarUsuario(int id)
    {
        var usuarioBorrar = _context.Usuarios.
                            Where(us => us.Id == id).SingleOrDefault();
        if (usuarioBorrar == null)
        {
            throw new EntidadNotFoundException();
        }
        _context.Remove(usuarioBorrar);
        _context.SaveChanges();
    }

    public List<Usuario> GetUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public void ModificarUsuario(Usuario usuario)
    {
        var usu = _context.Usuarios.Find(usuario.Id);
        if (usu == null)
        {
            throw new EntidadNotFoundException();
        }
        usu.Nombre = usuario.Nombre;
        usu.Apellido = usuario.Apellido;
        usu.Email = usuario.Email;
        usu.Contraseña = usuario.Contraseña;
        usu.Permisos = usuario.Permisos;
    }

    public Usuario ObtenerUsuario(int id_Usuario)
    {
        var usu = _context.Usuarios.Find(id_Usuario);
        return usu!;
    }
}
