using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class PersonaListarUseCase(IRepositorioPersona repoPer)
{
    public List<Persona> Ejecutar()
    {
        return repoPer.ListarPersonas();
    }
}
