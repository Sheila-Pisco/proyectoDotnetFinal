using System;
using System.Reflection.PortableExecutable;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; private set; }
    public string? Nombre { get;  set; }
    public string? Apellido { get;  set; }
    public string? Email { get;  set; }
    public string? Contraseña { get;  set; }
    public List<Permiso> Permisos { get; set; } = []; //garantiza que la lista nunca será nula y elimina la necesidad de comprobaciones adicionales y advertencias

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
        if (string.IsNullOrWhiteSpace(contraseña))
        {
            throw new ArgumentException("el campo contraseña no puede estar vacio");
        }
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Contraseña = contraseña;
        this.Permisos = lista;
    }
    public Usuario() { }
}
