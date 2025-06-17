using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    protected readonly CentroEventoContext _context;
    public RepositorioPersona(CentroEventoContext context)
    {
        _context = context;
    }

   public void AgregarPersona(Persona persona)
{
    var existe = _context.Personas.Any(per => per.Id == persona.Id);
    if (!existe)
    {
        _context.Personas.Add(persona);
        _context.SaveChanges();
        Console.WriteLine("Usuario Agregado con Éxito");
    }
    else
    {
        Console.WriteLine("El usuario ya existe con ese email.");
    }
}

    public void EliminarPersona(int id)
    {
        var personaBorrar = _context.Personas.
                            Where(per => per.Id == id).SingleOrDefault();
        if (personaBorrar == null)
        {
            throw new EntidadNotFoundException();
        }
        _context.Remove(personaBorrar);
        _context.SaveChanges();
    }

    public bool ExisteDniPersona(string dni)
    {
        return _context.Personas.Any(p => p.Dni == dni);
    }

    public bool ExisteEmail(string email)
    {
        return _context.Personas.Any(p => p.Email == email);

    }
    public bool ExisteIdPersona(int id)
    {
        return _context.Personas.Any(p => p.Id == id);
    }

    public List<Persona> ListarPersonas()
    {
        return _context.Personas.ToList(); //List<Persona> IEnumerable<Persona>.ToList<Persona>()
    }

    public void ModificarPersona(Persona persona)
    {
        var existePersona = _context.Personas.Find(persona.Id);

        if (existePersona == null)
        {
            throw new EntidadNotFoundException();
        }
        existePersona.Nombre = persona.Nombre;
        existePersona.Apellido = persona.Apellido;
        existePersona.Dni = persona.Dni;
        existePersona.Email = persona.Email;
        existePersona.Telefono = persona.Telefono;
        _context.SaveChanges();
    }
      public Persona ObtenerPersona(int idPersona)
    {
        var per = _context.Personas.Find(idPersona);
        return per!;
    }
}
