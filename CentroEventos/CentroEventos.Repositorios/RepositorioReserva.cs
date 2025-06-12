using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    public void AgregarReserva(Reserva reserva)
    {
        throw new NotImplementedException();
    }

    public int ContarReservasSegunEvento(int id_evento)
    {
        throw new NotImplementedException();
    }

    public void EliminarReserva(int id_reserva)
    {
        throw new NotImplementedException();
    }

    public bool ExisteCupo(int idEvento)
    {
        throw new NotImplementedException();
    }

    public bool ExisteReserva(int id_persona, int id_evento)  
    {
        throw new NotImplementedException();
    }

    public bool ExisteReservaAsociadaEvento(int id_evento)
    {
        throw new NotImplementedException();
    }

    public bool ExisteReservaAsociadaPersona(int id_persona)
    {
        throw new NotImplementedException();
    }

    public bool ExisteResposable(int IdResponsable)
    {
        throw new NotImplementedException();
    }

    public List<Persona> ListarAsistencia(int idEvento)
    {
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> ListarEventosConCupo()
    {
        throw new NotImplementedException();
    }

    public List<Reserva> ListarReserva()
    {
        throw new NotImplementedException();
    }

    public void ModificarReserva(Reserva reserva)
    {
        throw new NotImplementedException();
    }
}
