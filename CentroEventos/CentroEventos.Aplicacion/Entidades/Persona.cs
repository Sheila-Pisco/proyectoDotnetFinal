using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
    private int _Id;
    private string? _Dni;
    private string? _Nombre;
    private string? _Apellido;
    private string? _Email;//public Email {get;set;}--->pasa a ser una propiedad 
    private string? _Telefono;

    public Persona(string? dni ,string? ape,string? nom, string? email , string? tel)
    {
        // completar aquí las validaciones que aseguren la consistencia de la entidad
        
        this._Dni = dni; ///consulta a IrepositorioPersona
        this._Nombre = nom;
        this._Apellido =ape;
        this._Email = email; 
        this._Telefono = tel;
    }

    protected Persona() { } // Constructor vacío (lo utilizará EntityFramework)
    public int Id
    {
        get { return _Id; }
    }
    public string? Dni{
        get{return _Dni;}
        set{_Dni = value;}
    }
    public string? Nombre{
        get{return _Nombre;}
        set{ _Nombre = value;}
    }
    public string? Apellido{
        get{return _Apellido;}
        set{_Apellido = value;}
    }
    public string? Email{
        get { return this._Email;}
        set{_Email = value;}
    }
    public string? Telefono{
        get{ return  _Telefono;}
        set{}
    }
    public override string ToString(){
        string aux="";
        aux+= $"Persona: {this._Id} , dni: {this._Dni} , nombre: {this._Nombre} , apellido: {this._Apellido} , email: {this._Email} , telefono: {this._Telefono}";
        return aux;
    }
}
