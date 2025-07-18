using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
    public int Id { get; private set; }
    public string? Dni { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public Persona(string? dni ,string? ape,string? nom, string? email , string? tel)
    {
        this.Dni = dni; 
        this.Nombre = nom;
        this.Apellido =ape;
        this.Email = email; 
        this.Telefono = tel;
    }
    public Persona() { } // Constructor vacío (lo utilizará EntityFramework)
    public override string ToString(){
        string aux="";
        aux+= $"Persona: {this.Id} , dni: {this.Dni} , nombre: {this.Nombre} , apellido: {this.Apellido} , email: {this.Email} , telefono: {this.Telefono}";
        return aux;
    }
}
