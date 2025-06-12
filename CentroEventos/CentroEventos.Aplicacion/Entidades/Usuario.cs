using System;
using System.Reflection.PortableExecutable;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; private set; }
    public string? Nombre { get; private set; }
    public string? Apellido { get; private set; }
    public string? Email { get; private set; }
    public string? Contraseña { get; private set; }
    public List<Permiso>? Permisos { get; private set; }

    public Usuario(string nombre, string apellido, string email, string contraseña, List<Permiso> lista)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El campo nombre no puede estar vacio");
        }
        if (string.IsNullOrWhiteSpace(apellido))
        {
            throw new ArgumentException("El campo apellido no puede estar vacio");
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("el campo Email no puede estar Vacio");
        }
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Contraseña = contraseña;
        this.Permisos = lista;
    }
    protected Usuario()
    {
        
    }
}
