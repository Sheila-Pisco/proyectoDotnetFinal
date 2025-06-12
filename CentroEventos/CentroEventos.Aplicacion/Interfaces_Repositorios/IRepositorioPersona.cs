using System;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces_Repositorios;

public interface IRepositorioPersona
{
    public void AgregarPersona(Persona Persona);
    public List<Persona> ListarPersonas();
    public void EliminarPersona(int id);
    public void ModificarPersona(Persona persona);
    public bool ExisteDniPersona(string dni);
    public bool ExisteIdPersona(int id);
    public bool ExisteEmail(string email);
}
