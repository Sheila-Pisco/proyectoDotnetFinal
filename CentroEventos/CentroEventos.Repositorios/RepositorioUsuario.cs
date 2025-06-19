using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Enumerativos;
using System.Security.Cryptography;
using System.Text;
using CentroEventos.Aplicacion.Validadores;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    protected readonly CentroEventoContext _context;
    public RepositorioUsuario(CentroEventoContext context)
    {
        _context = context;
    }

    private static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convertir la cadena en un array de bytes
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            // Calcular el hash
            byte[] hashBytes = sha256.ComputeHash(bytes);
            // Convertir el hash a una cadena hexadecimal
            StringBuilder sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
    public void AgregarUsuario(Usuario usuario)
    {
        string hashedPassword = HashPassword(usuario.Contraseña!);
        var existe = _context.Usuarios.Any(u => u.Email == usuario.Email); //si la persona se quiere registrar con un mail que esta regustrado no lo va a dejar
        if (!existe)
        {
            usuario.Contraseña = hashedPassword;
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

    public Usuario BuscarUsuarioPorEmailyHash(string email, string contraseña)
    {
        string password = HashPassword(contraseña);
        var usu = _context.Usuarios.Where(e => e.Email == email).FirstOrDefault(); //devuelve el unico valor y devuelve null si no encuentra
        if (usu == null || usu.Contraseña != password)
        {
            throw new EntidadNotFoundException("Usuario no encontrado. Contraseña o Email incorrectos.");
        }
        return usu;
    }
    public bool ExisteEmail(string email)
    {
        return _context.Usuarios.Any(u => u.Email == email);

    }
    public void RegistrarUsuario(Usuario usuario)
    {
        this.AgregarUsuario(usuario);
    }
}
