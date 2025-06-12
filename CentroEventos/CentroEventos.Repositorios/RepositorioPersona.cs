using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    public void AgregarPersona(Persona Persona)
    {
        throw new NotImplementedException();
    }

    public void EliminarPersona(int id)
    {
        throw new NotImplementedException();
    }

    public bool ExisteDniPersona(string dni)
    {
        throw new NotImplementedException();
    }

    public bool ExisteEmail(string email)
    {
        throw new NotImplementedException();
    }
    public bool ExisteIdPersona(int id)
    {
        throw new NotImplementedException();
    }

    public List<Persona> ListarPersonas()
    {
        throw new NotImplementedException();
    }

    public void ModificarPersona(Persona persona)
    {
        throw new NotImplementedException();
    }
}
