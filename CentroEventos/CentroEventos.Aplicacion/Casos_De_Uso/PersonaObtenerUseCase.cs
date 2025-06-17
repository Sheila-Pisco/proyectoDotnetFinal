using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class PersonaObtenerUseCase(IRepositorioPersona repo)
{
    public Persona Ejecutar(int idPersona)
    {
        return repo.ObtenerPersona(idPersona);
    }
}
