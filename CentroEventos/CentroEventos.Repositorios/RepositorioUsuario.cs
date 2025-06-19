using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        var existe = _context.Usuarios.Any(u => u.Email == usuario.Email);
        if (!existe)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            Console.WriteLine("Usuario Agregado con Éxito");
        }
        else
        {
            Console.WriteLine("El usuario ya existe");
        }
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
        var usuarioExistente = _context.Usuarios.Find(usuario.Id);
        if (usuarioExistente == null)
        {
            throw new EntidadNotFoundException();
        }
        _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
        _context.SaveChanges();
    }

    public Usuario ObtenerUsuario(int id_Usuario)
    {
        var usu = _context.Usuarios.Find(id_Usuario);
        return usu!;
    }

    public bool BuscarPermiso(int id_Usuario, Permiso permiso)
    {
        var usuario = ObtenerUsuario(id_Usuario);
        return usuario?.Permisos != null && usuario.Permisos.Contains(permiso);
    }

    public Usuario BuscarUsuarioPorEmailyHash(string email, string codigoHash)
    {
        var usu = _context.Usuarios.Find(email);
        if (usu == null || usu.Contraseña != codigoHash)
        {
            throw new EntidadNotFoundException("Usuario no encontrado. Contraseña o Email incorrectos.");
        }
        return usu; 
    }
}
