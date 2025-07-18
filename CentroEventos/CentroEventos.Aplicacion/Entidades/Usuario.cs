using System;
using System.Reflection.PortableExecutable;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; private set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }
    public List<Permiso> Permisos { get; set; } = []; //garantiza que la lista nunca será nula y elimina la necesidad de comprobaciones adicionales y advertencias

    public Usuario(string nombre, string apellido, string email, string contraseña, List<Permiso> lista)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Contraseña = contraseña;
        this.Permisos = lista;
    }
    public Usuario() { }
    public override string ToString(){
        string aux="";
        aux+= $"Usuario Actual: {this.Nombre} {this.Apellido} ";
        return aux;
    }
}
