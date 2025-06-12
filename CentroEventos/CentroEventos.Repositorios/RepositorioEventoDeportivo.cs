using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    public void AgregarEvento(EventoDeportivo evento)
    {
        throw new NotImplementedException();
    }

    public void EliminarEvento(int id_evento)
    {
        throw new NotImplementedException();
    }

    public bool EsResponsableDeEvento(int id_persona)
    {
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> ListarEventos()
    {
        throw new NotImplementedException();
    }

    public void ModificarEvento(EventoDeportivo evento)
    {
        throw new NotImplementedException();
    }
}
